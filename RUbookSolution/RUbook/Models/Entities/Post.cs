using RUbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
        public string Image {get; set; }
        public virtual ApplicationUser UserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? GroupID { get; set; }
        public int? EventID { get; set; }

        public virtual List<Comment> Comments { get; set; }

       
    }
}