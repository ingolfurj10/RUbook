using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RUbook.DAL;
using RUbook.Models;
using Microsoft.AspNet.Identity;


namespace RUbook.DAL
{
    public class UserDAL
    {

        public ApplicationDbContext db = new ApplicationDbContext();

        public List<Post> GetAllPosts()
        {

			var posts = db.Posts.OrderByDescending(p => p.DateCreated).ToList();

            return posts;
       
        }
        public List<Group> GetAllGroups()
        {
            var groups = db.Groups.ToList();

            return groups;

        }

        public List<Event> GetAllEvents()
        {
            var events = db.Events.ToList();

            return events;

        }
    }

}

//Hérna viljum við hafa allar linq queries. 