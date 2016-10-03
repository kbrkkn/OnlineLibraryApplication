using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineLibraryApplication.DbContext;
using OnlineLibraryApplication.Models;

namespace OnlineLibraryApplication.Controllers
{
    public class BookInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookInfo/BookList
        public ActionResult BookList()//show all books from BookInfo table
        {
            var bookList = db.BookInfo.ToList();
            return View(bookList);
        }

        // GET: BookInfo/Details/5
        public ActionResult Details(int? id)//seçilen kitaptan kaç tane varsa hepsinin durumunu gösterir.
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfo.Find(id);
            bookInfo.Books = db.BookStatus.Where(x => x.BookInfoId == id).ToList();
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo.Books);
        }

       
     
       
    }
}
