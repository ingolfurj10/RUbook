using RUbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string text { get; set; }
        public string image {get; set; }
        public virtual ApplicationUser UserID { get; set; }
        //notum email eins og UserName?
        //public virtual ApplicationUser UserEmail { get; set; }
        public DateTime? DateCreated { get; set; }
        public Group GroupID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

       
    }
}