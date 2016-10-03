using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineLibraryApplication.Models
{
    public class BookStatus
    {//TABLE COLUMNS
        [Key]
        public int BookId { get; set; }
        public bool IsReserved { get; set; }
        public DateTime ReturnDate { get; set; }

        public int BookInfoId { get; set; }
        [ForeignKey("BookInfoId")]
        public virtual BookInfo BookInfo { get; set; }//navigation

    }
}