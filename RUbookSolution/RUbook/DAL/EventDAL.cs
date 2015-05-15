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
        /// <summary>
        /// Returns a single event with a id of the input
        /// </summary>
        /// <param name="eventid">event id</param>
        /// <returns></returns>
        public Event GetEvent(int eventid)
        {
            var eve = (from u in db.Events 
                       where u.ID == eventid 
                       select u).SingleOrDefault();

            return eve;
        }
        /// <summary>
        /// Gets all events that a single user is attending
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get all members of a single event 
        /// </summary>
        /// <param name="eid">event id</param>
        /// <returns></returns>
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