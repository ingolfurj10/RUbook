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
       
        //Here we have to connect users to group - list of users
       //public virtual ICollection<User> Users { get; set; }
        
        //here we have to allow posts on wall of group
        //public virtual ICollection<Post> Post { get; set; }*/
       
    }
}