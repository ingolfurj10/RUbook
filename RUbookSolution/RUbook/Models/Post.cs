﻿using RUbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string text { get; set; }
		//[ForeignKey("AspNetUsers")]
		//[Column(Order = 3)]
        public string userID { get; set; }
        public DateTime? DateCreated { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }
    }
}