using OnlineLibraryApplication.DbContext;
using OnlineLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;

namespace OnlineLibraryApplication.Controllers
{
    public class BookStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       //GET RESERVEBOOK
       [Authorize(Roles="User, Admin")]//Admin ve user kitap reserve edebilir

        public ActionResult ReserveBook(int? id)//reserve edilecek kitabı bulur ve o kitabı view'de döndürür.
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookStatus bs = db.BookStatus.Find(id);

            if (bs == null)
            {
                return HttpNotFound();
            }
            return View(bs);
        }

        //POST RESERVEBOOK
          [HttpPost]
          [ValidateAntiForgeryToken]
        public ActionResult ReserveBook(int id)//bulunan kitabı reserve eder.
    {
        BookStatus bs = db.BookStatus.Find(id);//book
        var UserId = User.Identity.GetUserId();//current user id
        ApplicationUser user = db.Users.Find(UserId);//current user

            if (ModelState.IsValid) {
               
           if (bs.IsReserved == false && user.Reserve_Count <= 3 && user.Reserve_Count > 0)//book is able
            {//kitap varsa ve kullanıcının kitap alma hakkı varsa
                bs.IsReserved = true;//book is reserved
                bs.ReturnDate = DateTime.Now.AddDays(7);//return date is one week later
                user.Reserve_Count--;//reserve book count --(from 3)

                UserHistory history = new UserHistory { BookStatus_Id = id, IsReserved = true,//action is saved to history
                ChangeTime=DateTime.Now,Id=UserId};
                db.UserHistory.Add(history);
                      

            }
            db.SaveChanges();//changes saved.

            return RedirectToAction("ListReservedBooks", "UserProfile");
           
            }//redirects to reserved books
            return View(bs);//model state is not valid,returns same book.
        }
           //GET     
        [Authorize(Roles = "User, Admin")]
          public ActionResult ReturnBook(int? id,int? hid )//reserve edilecek kitabı bulur ve o kitabı view'de döndürür.
          {
              if (id == null || hid==null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              BookStatus bs = db.BookStatus.Find(id);

              if (bs == null)
              {
                  return HttpNotFound();
              }
              return View(bs);
          }
        //POST
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult ReturnBook(int id,int hid)
          {
              BookStatus bs = db.BookStatus.Find(id);//book
              var UserId = User.Identity.GetUserId();//current user id
              ApplicationUser user = db.Users.Find(UserId);//current user

              if (ModelState.IsValid)
              {
                  if (user.Reserve_Count < 3 && user.Reserve_Count >= 0)
                  {//kullanıcı kitap aldıysa
                      bs.IsReserved = false;//book is free
                      bs.ReturnDate = DateTime.Now;//book is returned at that time
                      user.Reserve_Count++;
                      UserHistory updatedHistory = db.UserHistory.Find(hid);
                      updatedHistory.IsReserved = false;
                      updatedHistory.ChangeTime = DateTime.Now;

                  }
                  db.SaveChanges();//changes saved.

                  return RedirectToAction("ListReservedBooks", "UserProfile");
              }//redirects to booklist
              return View(bs);//model state is not valid,returns same book.
          }
    }
}