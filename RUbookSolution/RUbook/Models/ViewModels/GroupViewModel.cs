using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models.ViewModels
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
        public List<ApplicationUser> GroupMembers { get; set; }
        public List<Post> GroupPosts { get; set; }
        public bool CreatedByMe { get; set; }

    }
}