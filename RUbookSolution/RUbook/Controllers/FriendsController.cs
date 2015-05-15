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
    public class FriendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        UserDAL userDAL;

        public FriendsController():base()
        {
            userDAL = new UserDAL(db);
        }

        // GET: Friends
        public ActionResult Index()
        {
            return View(db.Friends.ToList());
        }

        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friends/Create
        public ActionResult Create(string id)
        {
            Friend ship = new Friend();
            ship.FriendUserID = userDAL.GetUser(id);
            ship.UserId = userDAL.GetUser(User.Identity.GetUserId());
           
            return View(ship);
        }

        // POST: Friends/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,FriendUserId")] Friend friend)
        {
            var uid = User.Identity.GetUserId();

            if (friend.FriendUserID.Id == uid)
            {
                return RedirectToAction("Error");
            }
            
            var user = userDAL.GetUser(uid);
            var fr = userDAL.GetUser(friend.FriendUserID.Id);

            var friendListId = userDAL.GetAllFriendsIds(uid);

            if(friendListId.Contains(friend.FriendUserID.Id))
            {
                return RedirectToAction("Error");
            }

            Friend ship = new Friend();
            ship.UserId = user;
            ship.FriendUserID = fr;
            ship.DateCreated = DateTime.Now;

            db.Friends.Add(ship);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult CreateFriend(string id)
        {
			//Find the id of the friend to befriend from the url
            string request = Request.ServerVariables["http_referer"];
            int posOfSlash = request.LastIndexOf('/');
            string fid = request.Substring(posOfSlash + 1);
 
            var uid = User.Identity.GetUserId();

			var friendship = userDAL.FindFriendShip(uid, fid);
			
			//If there exists a friendship go to error page
			if(friendship != null)
			{
				return RedirectToAction("CustomError", "Error");
			}

			// cannot befriend yourself
            if (id == uid)
            {
                return RedirectToAction("CustomError","Error");
            }

            var newFriend = new Friend();
            newFriend.UserId = userDAL.GetUser(uid);
            newFriend.FriendUserID = userDAL.GetUser(fid);
            newFriend.DateCreated = DateTime.Now;

            db.Friends.Add(newFriend);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult RemoveFriend()
        {
			//Find the id of the friend to remove from the url
            string request = Request.ServerVariables["http_referer"];
            int posOfSlash = request.LastIndexOf('/');
            string fid = request.Substring(posOfSlash + 1);

            var uid = User.Identity.GetUserId();

			var removeFriend = userDAL.FindFriendShip(uid, fid);
			
			//If friendship not found or an error occured redirect to an error page
			if(removeFriend == null)
			{
				RedirectToAction("CustomError","Error");
			}

            db.Friends.Remove(removeFriend);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
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
