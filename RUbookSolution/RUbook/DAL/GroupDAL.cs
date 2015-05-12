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

        public Group GetGroup(int groupid)
        {
            var group = (from u in db.Groups where u.ID == groupid select u).SingleOrDefault();

            return group;
        }

        public List<GroupMember> GetAllGroupsOfUser(string gid)
        {
            try
            {
                var group = db.GroupMembers.Where(p => gid.Contains(p.UserID.Id)).ToList();
                return group;
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
                //bæta við hérna dateAdded svo nýjasti komi fyrst eða í starfrófsröð bara - athuga virkar ekki 
                //var users = db.Friends.Where(p => uid.Contains(p.UserId.Id)).OrderByDescending(p => p.UserId.FirstName).ToList();
                var groups = db.Groups.ToList();
                return groups;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}