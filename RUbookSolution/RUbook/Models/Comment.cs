using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [Required]
        public int text { get; set; }
        public virtual ApplicationUser UserID { get; set; }
        public Post PostID { get; set; }
        public DateTime? CreatedDate { get; set; }
       
     }
}

