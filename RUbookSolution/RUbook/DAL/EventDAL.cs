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

namespace RUbook.DAL
{
    public class EventDAL
    {
        private ApplicationDbContext db;

        public EventDAL(ApplicationDbContext context)
        {
            db = context;
        }

        public Event GetEvent(int eventid)
        {
            var eve = (from u in db.Events 
                       where u.ID == eventid 
                       select u).SingleOrDefault();

            return eve;
        }

        public List<Event> GetAllEventsOfUser(string id)
        {
            try
            {
                var events = (from e in db.Events
                              join em in db.EventMembers on e.ID equals em.EventID
                              where em.UserID.Id == id
                              select e).ToList();
                return events;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public List<ApplicationUser> GetEventMembers(int? eid)
        {
            if (eid == null)
            {
                return null;
            }

            var emembers = (from gm in db.EventMembers
                            where gm.EventID == eid
                            select gm.UserID).ToList();

            return emembers;
        }
    }
}