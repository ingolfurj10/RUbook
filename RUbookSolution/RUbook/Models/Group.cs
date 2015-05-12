using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Group
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public string Image { get; set; }
        //public Department DepartmentID { get; set; }
        public string Course { get; set; }
        //public ApplicationUser userID { get; set; }

        public virtual List<GroupMember> GroupMembers { get; set; }
        public List<Post> Posts { get; set; }
       
    }
}