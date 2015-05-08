using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Friend
    {

        public int ID { get; set; }
        
        public virtual ApplicationUser user1 { get; set; }

		public virtual ApplicationUser user2 { get; set; }

    }
}

