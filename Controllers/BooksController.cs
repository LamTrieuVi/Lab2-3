using ReWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReWebApplication.Controllers
{
    public class BooksController : Controller
    {
        private List<Book> listBooks;
        public BooksController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                Id = 001,
                Title = "Sach 1",
                Author = "Nguyen Hoai Nam",
                PublicYear = 2015,
                Price = 140000,
                Cover = "Content/images/sach1.jpg",

            });

            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "Sach 2",
                Author = "Lam Trieu Vi",
                PublicYear = 2021,
                Price = 170000,
                Cover = "Content/images/sach2.png",

            });

            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "Sach 3",
                Author = "NXB Viet Nam",
                PublicYear = 2010,
                Price = 40000,
                Cover = "Content/images/sach3.jpg",

            });
        }
        
        public ActionResult ListBooks()
        {
            ViewBag.TitleNamePage = "Trang trưng bày sách";
            return View(listBooks);
        }

        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);

            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;
                    return View("ListBook", listBooks);
                }
                catch(Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Không thể thêm!");
                return View(book);
            }
        }
        public ActionResult Edit(int ? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(book);
        }
    }
}