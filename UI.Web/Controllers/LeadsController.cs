using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Leads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class LeadsController(ILeadService leadService) : BaseController
    {
        public IActionResult Index() => View(leadService.GetLeads(User));

        [Authorize(Roles = "ADM")]
        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = "ADM")]
        public async Task<IActionResult> Create(CreateLeadDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await leadService.CreateAsync(model);

                if (result.IsSuccess) return RedirectToAction(nameof(Index));

                foreach (var err in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }

        [HttpPost, Authorize(Roles = "ADM")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var result = await leadService.ImportFromFileAsync(file);

                if (!result.IsSuccess)
                {
                    TempData["Errors"] = result.Errors;
                }
            }
            else
            {
                TempData["Errors"] = new string[] { "Dosya boş!" };
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
