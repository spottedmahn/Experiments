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
        //this works
        //[Authorize(Roles = "SOME GROUP")]
        public IActionResult Index()
        {
            var blah1 = HttpContext.User.IsInRole("MY-COMPUTER-NAME\\SOME GROUP");
            var blah2 = HttpContext.User.IsInRole("SOME GROUP");
            return View();
        }

        [Authorize(AuthenticationSchemes = "Windows")]
        //this doesn't work
        //[Authorize(Roles = "SOME GROUP", AuthenticationSchemes = "Windows")]
        public ActionResult About()
        {
            var blah1 = HttpContext.User.IsInRole("MY-COMPUTER-NAME\\SOME GROUP");
            var blah2 = HttpContext.User.IsInRole("SOME GROUP");

            //this works though
            var windowsIdentity = HttpContext.User.Identity as WindowsIdentity;
            var windowsUser = new WindowsPrincipal(windowsIdentity);
            var role = "[MY-COMPUTER-NAME || AD GROUP NAME]\\[GROUP NAME]";
            var isInRole = windowsUser.IsInRole(role);

            ViewData["Message"] = $"isInRole: {isInRole}";

            return View();
        }

        //[Authorize("OMS API Orig")]
        [Authorize("OMS API")]
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
