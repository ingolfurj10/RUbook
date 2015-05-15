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
