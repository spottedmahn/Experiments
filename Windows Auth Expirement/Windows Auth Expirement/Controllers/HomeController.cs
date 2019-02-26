using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;
using Windows_Auth_Expirement.Models;

namespace Windows_Auth_Expirement.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        //[Authorize(Roles = "OMS API")]
        public IActionResult Index()
        {
            var blah1 = HttpContext.User.IsInRole("CEI-00638\\OMS API");
            var blah2 = HttpContext.User.IsInRole("OMS API");
            var blah3 = HttpContext.User.IsInRole(@"CEI.DOMAIN\CEI Corporate Portal Users Group");
            var blah4 = HttpContext.User.IsInRole("Domain Users");
            //var blah6 = HttpContext.User.IsInRole("Domain Users 2");
            var blah5 = HttpContext.User.Identity.AuthenticationType;
            return View();
        }

        [Authorize(AuthenticationSchemes = "Windows")]
        public ActionResult About()
        {
            var blah1 = HttpContext.User.IsInRole("CEI-00638\\OMS API");
            var blah2 = HttpContext.User.IsInRole("OMS API");
            var blah3 = HttpContext.User.IsInRole(@"CEI.DOMAIN\CEI Corporate Portal Users Group");
            var blah4 = HttpContext.User.IsInRole("Domain Users");
            var blah5 = HttpContext.User.Identity.AuthenticationType;
            var blah6 = HttpContext.User.IsInRole("Domain Users 2");

            //var blah9 = new ClaimsPrincipal(HttpContext.User.Identity);
            //var blah10 = blah9.IsInRole("CEI-00638\\OMS API");

            var blah8 = HttpContext.User.Identity as WindowsIdentity;
            var windowsUser = new WindowsPrincipal(blah8);
            var hasOmsApiRole = windowsUser.IsInRole("CEI-00638\\OMS API");

            ViewData["Message"] = $"hasOmsApiRole: {hasOmsApiRole}";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
