using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.Models.ViewModels
{
    public class ProfileViewModel
    {
        public List<Post> AllPosts { get; set; }
        public List<Group> AllGroups { get; set; }
        public List<Event> AllEvents { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }
        public Post Post { get; set; }
        public ApplicationUser User { get; set; }
        public List<GroupMember> AllGroupsOfUser { get; set; }
        public List<Friend> AllFriendsOfUser { get; set; }
        public List<EventMember> AllEventsOfUser { get; set; }

    }
}

 