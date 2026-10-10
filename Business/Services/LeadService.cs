using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Leads;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Utilities._585.Data.UnitOfWorks;
using Utilities._585.Helpers;
using Utilities._585.Models;

namespace Business.Services
{
    public class LeadService(IUnitOfWork unitOfWork, IMapper mapper) : ILeadService
    {
        public async Task<Reply> AddActivityAsync(ActivityType type, string leadId, ClaimsPrincipal user)
        {
            try
            {
                var repo = unitOfWork.GetRepository<Lead>();
                var lead = await repo.GetByKeyAsync(leadId);
                if (lead != null && lead.AssignedUserId == user.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    var activityRepo = unitOfWork.GetRepository<Activity>();
                    Activity activity = new()
                    {
                        Subject = $"{type}: {lead.Name}",
                        Type = type,
                        RelatedLeadId = leadId,
                        AssignedUserId = user.FindFirstValue(ClaimTypes.NameIdentifier),
                        DueDate = DateTime.Now,
                        CreatedAt = DateTime.Now
                    };

                    await activityRepo.CreateAsync(activity);
                    return await unitOfWork.CommitAsync();
                }
                return Reply.Fail("Veri veya kullanıcı bulunamadı!");
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
                throw;
            }
        }

        public async Task<Reply> AssignLeadAsync(string leadId, ClaimsPrincipal user)
        {
            try
            {
                var repo = unitOfWork.GetRepository<Lead>();
                var lead = await repo.GetByKeyAsync(leadId);
                if (lead != null)
                {
                    lead.AssignedUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                    lead.UpdatedAt = DateTime.Now;
                    repo.Update(lead);
                    return await unitOfWork.CommitAsync();
                }
                return Reply.Fail("Kayıt bulunamadı!");
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
            }
        }

        public async Task<Reply> CreateAsync(CreateLeadDto model)
        {
            try
            {
                var lead = mapper.Map<Lead>(model);
                var repo = unitOfWork.GetRepository<Lead>();
                await repo.CreateAsync(lead);
                return await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
            }
        }

        public IEnumerable<LeadListItemDto> GetLeads(ClaimsPrincipal user)
        {
            var repo = unitOfWork.GetRepository<Lead>();
            var query = repo.GetAll().Include(l => l.AssignedUser).AsQueryable();

            if (user.IsInRole("SP"))
            {
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                query = query.Where(l => l.AssignedUserId == userId || l.AssignedUserId == null);
            }

            var leads = query.AsEnumerable();
            return mapper.Map<IEnumerable<LeadListItemDto>>(leads);
        }

        public async Task<Reply> ImportFromFileAsync(IFormFile file)
        {
            try
            {
                using var stream = file.OpenReadStream();
                string ext = Path.GetExtension(file.FileName).ToLower();
                var result = ext switch
                {
                    ".csv" => await FileImportAdapter.FromCSVAsync<CreateLeadDto>(stream),
                    ".xlsx" => await FileImportAdapter.FromExcelAsync<CreateLeadDto>(stream),
                    ".json" => await FileImportAdapter.FromJsonCollectionAsync<CreateLeadDto>(stream),
                    _ => Reply<IEnumerable<CreateLeadDto>>.Fail("Desteklenmeyen dosya formatı!"),
                };

                if (result.IsSuccess)
                {
                    var importedLeads = mapper.Map<IEnumerable<Lead>>(result.Data);
                    var repo = unitOfWork.GetRepository<Lead>();
                    await repo.CreateManyAsync(importedLeads);
                    return await unitOfWork.CommitAsync();
                }
                return Reply.Fail(result.Errors!);
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);

            }
        }
    }
}
