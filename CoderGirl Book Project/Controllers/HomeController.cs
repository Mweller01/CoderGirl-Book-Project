using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_Book_Project.Models;

namespace CoderGirl_Book_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {

            return View();
        }

        public IActionResult Search()
        {

            return View();
        }

        public IActionResult Library()
        {
            ViewData["Message"] = "The books that you have read.";

            return View();
        }

        public IActionResult NewBook()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
