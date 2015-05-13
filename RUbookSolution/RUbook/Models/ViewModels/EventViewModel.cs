using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public List<ApplicationUser> EventMember { get; set; }
        public List<Post> EventPosts { get; set; }

    }
}