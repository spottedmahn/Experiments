using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Windows_Auth_Expirement_2._2.Models;

namespace Windows_Auth_Expirement_2._2.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var blah1 = HttpContext.User.IsInRole("CEI-00638\\OMS API");
            var blah2 = HttpContext.User.IsInRole("OMS API");
            var blah3 = HttpContext.User.IsInRole(@"CEI.DOMAIN\CEI Corporate Portal Users Group");
            var blah4 = HttpContext.User.IsInRole("Domain Users");
            var blah5 = HttpContext.User.Identity.AuthenticationType;

            return View();
        }

        [Authorize(AuthenticationSchemes = "Windows")]
        public IActionResult Privacy()
        {
            var blah1 = HttpContext.User.IsInRole("CEI-00638\\OMS API");
            var blah2 = HttpContext.User.IsInRole("OMS API");
            var blah3 = HttpContext.User.IsInRole(@"CEI.DOMAIN\CEI Corporate Portal Users Group");
            var blah4 = HttpContext.User.IsInRole("Domain Users");
            var blah5 = HttpContext.User.Identity.AuthenticationType;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
