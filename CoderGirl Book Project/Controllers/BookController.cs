using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_Book_Project.Models;

namespace CoderGirl_Book_Project.Controllers
{
    public class BookController : Controller
{


        private BooksContext _context;

        public BookController(BooksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }



}
}
