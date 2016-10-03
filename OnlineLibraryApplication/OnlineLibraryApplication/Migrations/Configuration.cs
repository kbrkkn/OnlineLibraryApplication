namespace OnlineLibraryApplication.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using OnlineLibraryApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineLibraryApplication.DbContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineLibraryApplication.DbContext.ApplicationDbContext context)
        {
            context.BookInfo.AddOrUpdate(x=>x.BookInfoId,
                new BookInfo()
                {
                    BookInfoId = 1,
                    Name = "Introduction To Algorithms",
                    Author = "Thomas H. Cormen",
                    Pages = 1000,
                    Publisher = "O'Reilly",
                    Language="English"
                },
         new BookInfo()
        {   BookInfoId=2,
            Name = "C Programming",
            Author = "Prof. Charles Leiserson ",
            Pages = 687,
            Publisher = "Deitel",
            Language="English"
        }, new BookInfo()
        {
            BookInfoId = 3,
            Name = "Java",
            Author = "Thomas H.",
            Pages = 1000,
            Publisher = "O'Reilly",
            Language = "English"
        },
         new BookInfo()
         {
             BookInfoId = 4,
             Name = "HTML",
             Author = "Prof.Leiserson ",
             Pages = 687,
             Publisher = "Deitel",
             Language = "English"
         },
            new BookInfo()
            {
                BookInfoId = 5,
                Name = "CSS",
                Author = "Prof.Leiserson ",
                Pages = 687,
                Publisher = "Deitel",
                Language = "English"
            });

            context.BookStatus.AddOrUpdate(x => x.BookId,
              new BookStatus() { BookId = 1,IsReserved = false, BookInfoId = 1, ReturnDate = DateTime.Now },
              new BookStatus() { BookId=2,IsReserved = false, BookInfoId = 1, ReturnDate = DateTime.Now },
              new BookStatus() { BookId=3,IsReserved = false, BookInfoId = 1, ReturnDate = DateTime.Now },
              new BookStatus() { BookId=4,IsReserved = false, BookInfoId = 2, ReturnDate = DateTime.Now },
              new BookStatus() { BookId=5,IsReserved = false, BookInfoId = 2, ReturnDate = DateTime.Now },
              new BookStatus() { BookId=6,IsReserved = false, BookInfoId = 2, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 7, IsReserved = false, BookInfoId = 3, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 8, IsReserved = false, BookInfoId = 3, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 9, IsReserved = false, BookInfoId = 4, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 10, IsReserved = false, BookInfoId = 4, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 11, IsReserved = false, BookInfoId = 5, ReturnDate = DateTime.Now },
              new BookStatus() { BookId = 12, IsReserved = false, BookInfoId = 5, ReturnDate = DateTime.Now });
          
            context.SaveChanges();
        }
       
    }
}
