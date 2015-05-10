using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RUbook.Models;
using RUbook.DAL;

namespace RUbook.Models
{
    public class TimelineViewModel
    {
       public List<Post> AllPosts { get; set; }
       public List<Group> AllGroups { get; set; }
       public List<Event> AllEvents { get; set; }
       public List<ApplicationUser> AllUsers { get; set; }
	 
	   public UserInfo UserInfo { get; set; }
       
        //public Post Post { get; set; } - til að ná í text area for post
    }
}