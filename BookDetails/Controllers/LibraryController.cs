using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDetails.Models;

namespace BookDetails.Controllers
{
    public class LibraryController : Controller
    {
        LibraryDBEntities librarydb = new LibraryDBEntities();

        // GET: Library
        public ActionResult Index()
        {
            var books = librarydb.book1_tbl.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        //Add books
        [HttpPost]
        public ActionResult AddBook(book1_tbl bookmodel)
        {
            librarydb.book1_tbl.Add(bookmodel);
            librarydb.SaveChanges();
            TempData["bookaddsuccess.message"] = $"({bookmodel.bookName}) added successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult editbook(book1_tbl Librarybookid)
        {
            var book = librarydb.book1_tbl.Where(y=>y.bookid==Librarybookid).FirstOrDefault();
            return View(book);

        }
        [HttpPost]
        public ActionResult editbook(book1_tbl bookmodel)
        {
            var book = librarydb.book1_tbl.Where(y => y.bookid == bookmodel.bookid).FirstOrDefault();
            if(book != null)
            {
                book.bookName = book.bookName;
                book.BookAuthor = book.BookAuthor;
                book.BookPrice = bookmodel.BookPrice;
                librarydb.SaveChanges();
                TempData["successfullmessage"] = $"{bookmodel.bookName} updated successfully";
            }
            return RedirectToAction("Index");
        }
    }
}