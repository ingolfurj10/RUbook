using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class EventMember
    {
        public int ID { get; set; }
        public virtual ApplicationUser UserID { get; set; }
        public int? EventID { get; set; }

    }
}