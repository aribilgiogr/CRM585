using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers
{
    public class CustomersController(ICustomerService service) : BaseController
    {
        public IActionResult Index() => View(service.GetCustomers(User));

        public async Task<IActionResult> Details(string id)
        {
            var model = await service.GetCustomerByIdAsync(id);
            if (model == null)
            {
                TempData["Errors"] = new string[] { "İlgili müşteri bulunamadı!" };
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
