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
        public string Text { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public int? GroupID { get; set; }
        public ApplicationUser UserID {get; set;}

        public virtual ICollection<EventMember> EventMembers { get; set; }
        public virtual List<Post> EventPosts { get; set; }
       

    }
}