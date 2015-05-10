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

        private ApplicationDbContext db;

        public UserDAL(ApplicationDbContext context)
        {
            db = context;
        }

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

        public List<ApplicationUser> GetAllUsers()
        {

            var users = db.Users.ToList();

            return users;

        }

        public ApplicationUser GetUser (string userid)
        {
            var user = (from u in db.Users where u.Id == userid select u).SingleOrDefault();

            return user;
        }
		
		public UserInfo GetUserInfo(ApplicationUser user)
		{
			var userInfo = (from u in db.UsersInfo
						    where u.UserID == user
							select u)
						    .SingleOrDefault();
			return userInfo;
						   
		}
		
    }

}

//Hérna viljum við hafa allar linq queries. 