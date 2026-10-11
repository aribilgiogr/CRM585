using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Customers;
using Core.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Utilities._585.Data.UnitOfWorks;

namespace Business.Services
{
    public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : ICustomerService
    {
        public async Task<CustomerDetailDto?> GetCustomerByIdAsync(string customerId)
        {
            var repo = unitOfWork.GetRepository<Customer>();
            var customer = await repo.GetAll()
                                     .Include(c => c.Activities).ThenInclude(a => a.AssignedUser)
                                     .Include(c => c.Opportunities)
                                     .Include(c => c.AssignedUser)
                                     .Include(c => c.ConvertedFromLead).ThenInclude(c => c.Activities).ThenInclude(a => a.AssignedUser)
                                     .FirstOrDefaultAsync(c => c.Id == customerId);

            return mapper.Map<CustomerDetailDto>(customer);
        }

        public IEnumerable<CustomerListItemDto> GetCustomers(ClaimsPrincipal user)
        {
            var repo = unitOfWork.GetRepository<Customer>();
            var query = repo.GetAll()
                            .Include(c => c.Activities)
                            .Include(c => c.Opportunities)
                            .Include(c => c.AssignedUser)
                            .Include(c => c.ConvertedFromLead)
                            .AsQueryable();

            if (user.IsInRole("SP"))
            {
                var currentUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                query = query.Where(c => c.AssignedUserId == currentUserId);
            }

            var customers = query.AsEnumerable();
            return mapper.Map<IEnumerable<CustomerListItemDto>>(customers);
        }
    }
}
