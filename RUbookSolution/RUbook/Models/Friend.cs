using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Models
{
    public class Friend
    {

        public int ID { get; set; }
        
        public ApplicationUser CurrentUserID { get; set; }

        public ApplicationUser FriendUserID { get; set; }

    }
}

