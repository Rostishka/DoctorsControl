using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestCore.Models;

namespace TestCore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About(int Id)
        {
            ViewData["Message"] = "Your application description page.";

            return View("Index");
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
