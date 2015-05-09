using RUbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Event
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime? DateOfEvent { get; set; }
        [Required]
        public string Location { get; set; }
        //ekki búið að tengja ennþá
        public Department DepartmentID { get; set; }
        //ekki búið að tengja ennþá
        public Group GroupID { get; set; }

        public virtual ICollection<EventMember> EventMembers { get; set; }
       

    }
}