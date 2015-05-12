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

        // GET: GroupMembers
        public ActionResult Index()
        {
            return View(db.GroupMembers.ToList());
        }

        // GET: GroupMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            return View(groupMember);
        }

        // GET: GroupMembers/Create
     
        public ActionResult Create(int id)
        {
            GroupMember group = new GroupMember();
            group.GroupID = groupDAL.GetGroup(id);
            group.UserID = userDAL.GetUser(User.Identity.GetUserId());
            
            return View(group);
        }

        // POST: GroupMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,GroupID")] GroupMember groupMember)
        {
            var uid = User.Identity.GetUserId();

            //if (id == uid)
            //{
            //     ekki hægt að vera vinur sinn
            //}

            var user = userDAL.GetUser(uid);
            var gr = groupDAL.GetGroup(groupMember.GroupID.ID);

            GroupMember member = new GroupMember();
            member.UserID = user;
            member.GroupID = gr;

            db.GroupMembers.Add(member);

            db.SaveChanges();

            return RedirectToAction("Details", "Groups", new { id = gr.ID });
        }

        // GET: GroupMembers/Edit/5
        public ActionResult Edit(int? id)
        {testc 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            return View(groupMember);
        }

        // POST: GroupMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] GroupMember groupMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupMember);
        }

        // GET: GroupMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            return View(groupMember);
        }

        // POST: GroupMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupMember groupMember = db.GroupMembers.Find(id);
            db.GroupMembers.Remove(groupMember);
            db.SaveChanges();
            return RedirectToAction("Index");
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
