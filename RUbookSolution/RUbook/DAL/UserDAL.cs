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

        public List<ApplicationUser> GetFriends(string id)
        {
            try
            {
                var friends = db.Friends.Where(f => id.Contains(f.UserId.Id)).OrderByDescending(f => f.DateCreated).Select(f => f.FriendUserID).ToList();
                return friends;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public List<string> GetAllFriendsIds(string id)
        {
            try
            {
                var friendsIds = db.Friends.Where(p => id.Contains(p.UserId.Id)).Select(p => p.FriendUserID.Id).ToList();
                return friendsIds;
            }
            catch(Exception ex)
            { 
                //If no friends do nothing
            }

            return null;
        }

        public List<ApplicationUser> GetFollowers(string id)
        {
            var followers = db.Friends.Where(f => f.FriendUserID.Id == id)
                              .OrderByDescending(f => f.DateCreated)
                              .Select(f => f.UserId).ToList();

            return followers;
        }

        public Friend FindFriendShip(string userId, string friendId)
        {
            var ship = db.Friends.Where(f => f.FriendUserID.Id == friendId).Where(f => f.UserId.Id == userId).Select(f => f).SingleOrDefault();
            return ship;
        }
    }

}
