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

        /// <summary>
        /// Gets a list of all users of the system
        /// </summary>
        /// <returns></returns>
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

       /// <summary>
        /// Gets a  single user of the system 
       /// </summary>
       /// <param name="userid"></param>
       /// <returns></returns>
        public ApplicationUser GetUser (string userid)
        {
            var user = (from u in db.Users where u.Id == userid select u).SingleOrDefault();
            return user;
        }

        /// <summary>
        /// //get list of friends of certain user with the id from the input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ApplicationUser> GetFriends(string id)
        {
            try
            {
                var friends = db.Friends.Where(f => id.Contains(f.UserId.Id))
                                        .OrderByDescending(f => f.DateCreated)
                                        .Select(f => f.FriendUserID).ToList();
                return friends;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        /// <summary>
        /// return a list of only the ids of the users that a single user is following
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// returns followers of user with the id from the input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
 
        public List<ApplicationUser> GetFollowers(string id)
        {
            var followers = db.Friends.Where(f => f.FriendUserID.Id == id)
                              .OrderByDescending(f => f.DateCreated)
                              .Select(f => f.UserId).ToList();

            return followers;
        }

        /// <summary>
        /// Returns an instance of the Friend connection between two users
		/// If no Friend connection is in place returns null
        /// </summary>
        /// <param name="userId">The id of logged in user</param>
        /// <param name="friendId">The id of the friend in question</param>
        /// <returns></returns>
        public Friend FindFriendShip(string userId, string friendId)
        {
			try
			{ 
				var ship = db.Friends.Where(f => f.FriendUserID.Id == friendId)
                                 .Where(f => f.UserId.Id == userId)
                                 .Select(f => f).SingleOrDefault();
				return ship;
        
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}
    }

}
