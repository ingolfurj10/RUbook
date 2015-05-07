﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int text { get; set; }
        public virtual ApplicationUser UserID { get; set; }
        public Post PostID { get; set; }
        public DateTime? CreatedDate { get; set; }
       
     }
}
