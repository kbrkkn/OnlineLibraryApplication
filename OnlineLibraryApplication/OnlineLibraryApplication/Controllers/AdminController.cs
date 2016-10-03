using OnlineLibraryApplication.DbContext;
using OnlineLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibraryApplication.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      
        [Authorize(Roles="Admin")]//list of users' reserved books.Only admin can see.
        public ActionResult ShowUsersHistory()
        {
            var list = ShowUsersActions(true);
            return View(list);
        }
        public IEnumerable<UserHistory> ShowUsersActions(bool IsReserved) {
         var list = db.UserHistory.Where(x => x.IsReserved==IsReserved).ToList();
         return list;
        }
    }
}