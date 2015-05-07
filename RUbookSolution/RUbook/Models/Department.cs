using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}