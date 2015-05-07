using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public Department departmentID { get; set; }
        public string course { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<Post> Post { get; set; }
       
    }
}