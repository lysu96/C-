using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lyasu_cnttk14e.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lyasu_cnttk14e.Controllers
{
    public class BookListController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewData["Message"] = "Message From Đata";
            ViewData["CurrenTime"] = DateTime.Now;
            return View();
        }
        public ActionResult BookList()
        {
            var books = new List<Book>();
            books.Add(new Book
            {
                IdBook = 1,
                BookName = "Lập trình c#",
                Author = "Nguyễn văn A",
                ImgeCover = "../images/book c.png"
            });
            books.Add(new Book
            {
                IdBook = 2,
                BookName = "Lập trình databasebox",
                Author = "Nguyễn văn A",
                ImgeCover = "../images/book databasebox.png"
            });
            books.Add(new Book
            {
                IdBook = 3,
                BookName = "Lập trình javascriptbox",
                Author = "Nguyễn văn A",
                ImgeCover = "../images/book javascriptbox.png"
            });

            return View(books);
        }

    }
}
