using CoderGirl_Book_Project.Data;
using CoderGirl_Book_Project.Models;
using CoderGirl_Book_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_Book_Project.Controllers
{
    public class NewBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewBook.ToListAsync());
        }


        // GET: NewBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newBook = await _context.NewBook
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newBook == null)
            {
                return NotFound();
            }

            return View(newBook);
        }

        // GET: NewBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "Id,Title,Cover,Description,Author,Category,Rating,Tag")] NewBook newBook)
        {
            if (ModelState.IsValid)
            {
                var NewBook = new Books
                {
                    Id = newBook.Id,
                    Title = newBook.Title,
                    Cover = newBook.Cover,
                    Description = newBook.Description,
                    

                };


                var author = new Author
                {
                    Author1 = newBook.Author
                };


                var category = new Categories
                {
                    Category = newBook.Category,
                };

                var rating = new Ratings
                {
                    Rating = newBook.Rating
                };

                var tag = new Tags
                {
                    Tag = newBook.Tag
                };
                    

                _context.Add(newBook);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newBook);
        }

        // GET: NewBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newBook = await _context.NewBook.SingleOrDefaultAsync(m => m.Id == id);
            if (newBook == null)
            {
                return NotFound();
            }
            return View(newBook);
        }

        // POST: NewBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Cover,Description,Author,Category,Rating,Tag")] NewBook newBook)
        {
            if (id != newBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewBookExists(newBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(newBook);
        }

        // GET: NewBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newBook = await _context.NewBook
                .SingleOrDefaultAsync(m => m.Id == id);
            if (newBook == null)
            {
                return NotFound();
            }

            return View(newBook);
        }

        // POST: NewBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newBook = await _context.NewBook.SingleOrDefaultAsync(m => m.Id == id);
            _context.NewBook.Remove(newBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewBookExists(int id)
        {
            return _context.NewBook.Any(e => e.Id == id);
        }
    }
}
