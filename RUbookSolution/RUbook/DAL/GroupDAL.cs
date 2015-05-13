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
    public class GroupDAL
    {
        private ApplicationDbContext db;

        public GroupDAL(ApplicationDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Returns the group with the groupid input
        /// </summary>
        /// <param name="groupid">id of the group</param>
        /// <returns></returns>
        public Group GetGroup(int groupid)
        {
            var group = (from u in db.Groups where u.ID == groupid select u).SingleOrDefault();

            return group;
        }

        public List<Group> GetAllGroupsOfUser(string id)
        {
            try
            {
                //var group = db.GroupMembers.Where(p => gid.Contains(p.UserID.Id)).ToList();
                var groups = (from g in db.Groups
                             join gm in db.GroupMembers on g.ID equals gm.GroupID
                             where gm.UserID.Id == id
                             select g).ToList();
                return groups;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public List<Group> GetAllGroups()
        {
            try
            {
                var groups = db.Groups.ToList();
                return groups;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public List<ApplicationUser> GetGroupMembers(int? gid)
        {
            if (gid == null)
            {
                return null;
            }

            var gmembers = (from gm in db.GroupMembers
                            where gm.GroupID == gid
                            select gm.UserID).ToList();

            return gmembers;
        }
    }
}