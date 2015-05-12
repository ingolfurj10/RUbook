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
        
        public List<Friend> AllFriendsOfUser(string gid)
        {
            try
            {
                var friends = db.Friends.Where(p => gid.Contains(p.UserId.Id)).ToList();
                return friends;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
		
    }

}
