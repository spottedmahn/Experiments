using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DI_2.Models;
using DI2.Models;

namespace DI_2.Controllers
{
    public class HomeController : Controller
    {
        private MyObject myObject;

        public HomeController(MyObject myObject)
        {
            this.myObject = myObject;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = myObject.Message;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
