using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineLibraryApplication.Models;

namespace OnlineLibraryApplication.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LibraryConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //DATABASE TABLES
        public DbSet<BookInfo> BookInfo { get; set; }
        public DbSet<BookStatus> BookStatus { get; set; }
        public DbSet<UserHistory> UserHistory { get; set; }
    }
}