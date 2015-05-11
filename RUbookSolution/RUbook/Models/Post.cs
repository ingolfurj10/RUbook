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
        //notum email eins og UserName? - hvernig sækjum við úr töflu þessari töflu sem er ekki primary key
        public DateTime? DateCreated { get; set; }
        //ekki búið að tengja
        public Group GroupID { get; set; }

        public virtual List<Comment> Comments { get; set; }

       
    }
}