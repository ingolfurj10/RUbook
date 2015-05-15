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
using RUbook.Models.ViewModels;

namespace RUbook.Controllers
{
    public class GroupMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        GroupDAL groupDAL;
        UserDAL userDAL;

        public GroupMembersController():base()
        {
            groupDAL = new GroupDAL(db);
            userDAL = new UserDAL(db);
        }
        
        // GET: GroupMembers/Create
        public ActionResult Create(int id)
        {
            GroupMemberViewModel g = new GroupMemberViewModel();
            var group = groupDAL.GetGroup(id);

            g.GroupId = group.ID;
            g.GroupName = group.Name;
            
            return View(g);
        }

        // POST: GroupMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId")] GroupMemberViewModel model)
        {
            var uid = User.Identity.GetUserId();
            var user = userDAL.GetUser(uid);

            GroupMember gm = new GroupMember();
            gm.GroupID = model.GroupId;
            gm.UserID = user;

            db.GroupMembers.Add(gm);
            db.SaveChanges();

            return RedirectToAction("Details", "Groups", new { id = gm.GroupID });
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
