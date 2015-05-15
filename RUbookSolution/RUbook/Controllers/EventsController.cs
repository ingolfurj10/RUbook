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
    
    public class EventsController : Controller
    {   
        private ApplicationDbContext db = new ApplicationDbContext();
        private EventDAL eventDAL;
        private PostDAL postDAL;

        public EventsController() : base()
        {
            eventDAL = new EventDAL(db);
            postDAL = new PostDAL(db);
        }
       

        // GET: Events
        [Authorize]
        
        public ActionResult Index()
        {
            return View(db.Events.OrderByDescending(p => p.DateOfEvent).ToList());
        }

        // GET: Events/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PageNotFound","Error");
            }

            EventViewModel model = new EventViewModel();
            var ev = eventDAL.GetEvent((int)id);
            
            if (ev == null)
            {
                return HttpNotFound();
            }

            model.Event = ev;
            model.EventMember = eventDAL.GetEventMembers(id);
            model.EventPosts = postDAL.GetEventPosts(id);

            return View(model);
        }

        // GET: Events/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,DateOfEvent,Image,Location,Text,GroupID,userID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = @event.ID });
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name,DateOfEvent,Image,Location,Text,GroupID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = @event.ID });
            }
            return View(@event);
        }

        //// GET: Events/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = db.Events.Find(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Event @event = db.Events.Find(id);
        //    db.Events.Remove(@event);
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
