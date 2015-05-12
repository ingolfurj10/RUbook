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
    public class EventMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        EventDAL eventDAL;
        UserDAL userDAL;

        public EventMembersController():base()
        {
            eventDAL = new EventDAL(db);
            userDAL = new UserDAL(db);
        }

        // GET: EventMembers
        public ActionResult Index()
        {
            return View(db.EventMembers.ToList());
        }

        // GET: EventMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            return View(eventMember);
        }

        // GET: EventMembers/Create
        public ActionResult Create(int id)
        {
            EventMember eve = new EventMember();
            eve.EventID = id;
            eve.UserID = userDAL.GetUser(User.Identity.GetUserId());

            return View(eve);
        }

        // POST: EventMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] EventMember eventMember)
        {
            var uid = User.Identity.GetUserId();

            //if (id == uid)
            //{
            //     ekki hægt að joina tvisvar sama event. Contains
            
            //}

            var user = userDAL.GetUser(uid);

            EventMember member = new EventMember();
            member.UserID = user;
            member.EventID = eventMember.ID;

            db.EventMembers.Add(member);

            db.SaveChanges();

            return RedirectToAction("Details", "Events", new { id = eventMember.ID });
        }

        // GET: EventMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            return View(eventMember);
        }

        // POST: EventMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] EventMember eventMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventMember);
        }

        // GET: EventMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            return View(eventMember);
        }

        // POST: EventMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventMember eventMember = db.EventMembers.Find(id);
            db.EventMembers.Remove(eventMember);
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
