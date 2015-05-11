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
    }
}