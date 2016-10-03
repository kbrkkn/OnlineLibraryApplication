using OnlineLibraryApplication.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineLibraryApplication.Models;
namespace OnlineLibraryApplication.Controllers
{
    public class UserProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ListReservedBooks()
        {
            var listReservedBooks = ShowMyActions(true);

            return View(listReservedBooks);
        }
        public ActionResult ListReturnedBooks() {
            var listReturnedBooks = ShowMyActions(false);
            return View(listReturnedBooks);
        }

        private IEnumerable<UserHistory> ShowMyActions(bool IsReserved)
        {
            var userId = User.Identity.GetUserId();
            var myHistory = db.UserHistory.Where(x => x.Id == userId).ToList();
            var listActions = myHistory.Where(y => y.IsReserved == IsReserved);
            return listActions;
        }

       
    }
}