using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_Book_Project.Controllers
{
    public class CategoryController : Controller

        //I created a category controller since I couldn't figure out how to access views in a subfolder of home
    {
        public IActionResult HighFantasy()
        {
            return View();
        }

        public IActionResult HistoricalFantasy()
        {

            return View();
        }

        public IActionResult ScienceFiction()
        {

            return View();
        }

        public IActionResult Steampunk()
        {

            return View();
        }

        public IActionResult Superheroes()
        {

            return View();
        }

        public IActionResult UrbanFantasy()
        {

            return View();
        }

    }
}