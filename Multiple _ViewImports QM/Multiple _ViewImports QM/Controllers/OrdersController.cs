using Microsoft.AspNetCore.Mvc;

namespace MultipleViewImportsQm.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
