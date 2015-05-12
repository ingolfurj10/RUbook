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
    public class UserInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserDAL userDAL;

        public UserInfoesController() : base()
        {
            userDAL = new UserDAL(db);
        }

        // GET: UserInfoes
        public ActionResult Index()
        {
            return View(userDAL.GetAllUsers());
        }

        // GET: UserInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser userInfo = userDAL.GetUser(id);
           
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName, DateOfBirth, Education, WorkInfo, Department, Image")] ApplicationUser userInfo)
        {
            var uid = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                //var original = db.Users.SingleOrDefault(u => u.Id == userInfo.Id);
                
                var original = userDAL.GetUser(uid);
                if (original != null)
                {
                    original.FirstName = userInfo.FirstName;
                    original.LastName = userInfo.LastName;
                    original.DateOfBirth = userInfo.DateOfBirth;
                    original.Education = userInfo.Education;
                    original.WorkInfo = userInfo.WorkInfo;
                    original.Department = userInfo.Department;
                    original.Image = userInfo.Image;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Details", new { id = uid });
            //return View(userInfo);
        }

        // GET: UserInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var user = userDAL.GetUser(id);
            //UserInfo userInfo = db.UsersInfo.Find(id);
            //if (userInfo == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(userInfo);
            return View(user);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName, DateOfBirth, Education, WorkInfo, Department, Image")] ApplicationUser userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserInfo userInfo = db.UsersInfo.Find(id);
            //if (userInfo == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(userInfo);
            return null;
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //UserInfo userInfo = db.UsersInfo.Find(id);
            //db.UsersInfo.Remove(userInfo);
            //db.SaveChanges();
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
