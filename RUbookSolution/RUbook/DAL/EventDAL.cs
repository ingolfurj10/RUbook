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
    public class EventDAL
    {
        private ApplicationDbContext db;

        public EventDAL(ApplicationDbContext context)
        {
            db = context;
        }

        public Event GetEvent(int eventid)
        {
            var eve = (from u in db.Events where u.ID == eventid select u).SingleOrDefault();

            return eve;
        }

        public List<EventMember> GetAllEventsOfUser(string gid)
        {
            try
            {
                var events = db.EventMembers.Where(p => gid.Contains(p.UserID.Id)).ToList();
                return events;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public List<Event> GetAllEvents()
        {
            try
            {
                var events = db.Events.ToList();
                return events;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}