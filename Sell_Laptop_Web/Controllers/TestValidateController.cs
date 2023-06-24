using Microsoft.AspNetCore.Mvc;

namespace Sell_Laptop_Web.Controllers
{
    public class TestValidateController : Controller
    {
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return Content("?????????");

        }
    }
}
