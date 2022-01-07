using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBibliotek.Data;
using WebAppBibliotek.Models;

namespace WebAppBibliotek.Controllers
{
    public class BookController : Controller
    {
        private readonly WebAppDBContext _db;

        public BookController(WebAppDBContext db)
        {
            _db = db;
        }

        public List<Book> _books { get; set; }

        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _db.Books;
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostDelete(Book book)
        {

            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sort(string _sortTerm)
        {
                    
            var sortResults = from b in _db.Books where b._genre.Contains(_sortTerm) select b;
            

            return View("Index", sortResults);
        }

        [HttpPost]
        public IActionResult SortAuthor(string _sortTerm)
        {

            var sortResults = from b in _db.Books select b;
            var sortedResults = sortResults;
            switch (_sortTerm)
            {
                case "AuthorAZ":
                    sortedResults = sortResults.OrderBy(a => a._author);
                    break;
                case "AuthorZA":
                    sortedResults = sortResults.OrderByDescending(a => a._author);
                    break;
                default:
                    return View();                  
            }


            return View("Index", sortedResults);
        }
    }
}
