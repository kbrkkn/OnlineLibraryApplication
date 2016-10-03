using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineLibraryApplication.Models
{
    public class BookInfo
    {
        [Key]
        public int BookInfoId { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public int Pages { get; set; }
        public String Publisher { get; set; }
        public String Language { get; set; }
        public List<BookStatus> Books { get; set; }
    }
}