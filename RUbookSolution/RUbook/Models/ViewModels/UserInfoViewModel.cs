using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RUbook.Models;

namespace RUbook.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        public Whois whois { get; set; }
    }

    public enum Whois
    {
        Me,
        Friend,
        NotFriend
    }
}