using Microsoft.AspNetCore.Mvc;

namespace Multiple__ViewImports_QM.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
