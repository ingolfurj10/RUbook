using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int text { get; set; }
        public int userID { get; set; }
        public DateTime? CreatedDate { get; set; }
        

        //public virtual Course Course { get; set; }
        //public virtual Student Student { get; set; }
    }
}

