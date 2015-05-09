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
        public string text { get; set; }
        public string image {get; set; }
        public virtual ApplicationUser UserID { get; set; }
        //notum email eins og UserName? - hvernig sækjum við úr töflu þessari töflu sem er ekki primary key
        public DateTime? DateCreated { get; set; }
        //ekki búið að tengja
        public Group GroupID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

       
    }
}