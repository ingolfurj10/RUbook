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

        //// GET: EventMembers
        //public ActionResult Index()
        //{
        //    return View(db.EventMembers.ToList());
        //}

        //// GET: EventMembers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EventMember eventMember = db.EventMembers.Find(id);
        //    if (eventMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eventMember);
        //}

        // GET: EventMembers/Create
        public ActionResult Create(int id)
        {
            EventMemberViewModel e = new EventMemberViewModel();
            var eve = eventDAL.GetEvent(id);

            e.EventId = eve.ID;
            e.EventName = eve.Name;

            return View(e);
        }

        // POST: EventMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId")] EventMember model)
        {
            var uid = User.Identity.GetUserId();
            var user = userDAL.GetUser(uid);

            EventMember em = new EventMember();
            em.EventID = model.EventID;
            em.UserID = user;

            db.EventMembers.Add(em);
            db.SaveChanges();

            return RedirectToAction("Details", "Events", new { id = em.EventID });
        }

        //// GET: EventMembers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EventMember eventMember = db.EventMembers.Find(id);
        //    if (eventMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eventMember);
        //}

        //// POST: EventMembers/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID")] EventMember eventMember)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(eventMember).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(eventMember);
        //}

        //// GET: EventMembers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EventMember eventMember = db.EventMembers.Find(id);
        //    if (eventMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eventMember);
        //}

        //// POST: EventMembers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    EventMember eventMember = db.EventMembers.Find(id);
        //    db.EventMembers.Remove(eventMember);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
