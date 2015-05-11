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
            try
            {
                //bæta við hérna dateAdded svo nýjasti komi fyrst eða í starfrófsröð bara - athuga virkar ekki 
                //var users = db.Friends.Where(p => uid.Contains(p.UserId.Id)).OrderByDescending(p => p.UserId.FirstName).ToList();
                var users = db.Users.ToList();
                return users;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null; 
        }

        public ApplicationUser GetUser (string userid)
        {
            var user = (from u in db.Users where u.Id == userid select u).SingleOrDefault();
            return user;
        }
		
        //public ApplicationUser GetUserInfo(ApplicationUser user)
        //{
        //    var userInfo = (from u in db.UsersInfo
        //                    where u.UserID == user
        //                    select u)
        //                    .SingleOrDefault();
        //    return userInfo;
						   
        //}
		
    }

}

//Hérna viljum við hafa allar linq queries. 