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
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private GroupDAL groupDAL;
        private PostDAL postDAL;
        private UserDAL userDAL;

        public GroupsController() : base()
        {
            groupDAL = new GroupDAL(db);
            postDAL = new PostDAL(db);
            userDAL = new UserDAL(db);
        }

        // GET: Groups
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: Groups/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GroupViewModel model = new GroupViewModel();
            var group = groupDAL.GetGroup((int)id);

            if (group == null)
            {
                //TODO skila error eða einhverju um að grúppan sé ekki til.
                return HttpNotFound();
            }

            model.Group = group;
            model.GroupMembers = groupDAL.GetGroupMembers(id);
            model.GroupPosts = postDAL.GetGroupPosts(id);

            if(group.userID.Id == User.Identity.GetUserId())
            {
                model.CreatedByMe = true;
            }
            else
            {
                model.CreatedByMe = false;
            }

            return View(model);
        }

        // GET: Groups/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,Text,Course,Image")] Group group)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();
                group.userID = user;
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = group.ID });
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name,Text,Course,Image")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = group.ID });
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
