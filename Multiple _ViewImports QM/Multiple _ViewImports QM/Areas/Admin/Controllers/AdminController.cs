using Microsoft.AspNetCore.Mvc;

namespace MultipleViewImportsQm.Areas.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
