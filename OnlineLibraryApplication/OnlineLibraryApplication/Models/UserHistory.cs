using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineLibraryApplication.Models
{
    public class UserHistory
    {
        [Key]
        public int UserHistory_Id { get; set; }

        public int BookStatus_Id { get; set; }
        [ForeignKey("BookStatus_Id")]
        public virtual BookStatus BookStatus { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime ChangeTime { get; set; }
        public bool IsReserved { get; set; }
    }
}