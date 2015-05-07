using RUbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime? DateOfEvent { get; set; }
        public Department departmentID { get; set; }

        public virtual ICollection<EventMember> EventMembers { get; set; }
       

    }
}