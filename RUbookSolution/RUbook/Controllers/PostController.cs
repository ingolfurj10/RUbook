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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RUbook.Controllers
{
    public class PostController : Controller
    {
        public  ApplicationDbContext db = new ApplicationDbContext();
        UserDAL userDAL;
        PostDAL postDAL;
        GroupDAL groupDAL;

        public PostController() : base()
        {
            userDAL = new UserDAL(db);
            postDAL = new PostDAL(db);
            groupDAL = new GroupDAL(db);
        }

        // GET: Post
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = userDAL.GetUser(userId);
            //var group = groupDAL.GetGroup();

            try
            {
                //var friends = (from u in db.Friends where u.UserId.Id == user.Id select u.FriendUserID.Id).ToList();
                //friends.Add(userId);
                //var posts = postDAL.(friends);
                //return View(db.Posts.ToList());

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return null;
        }

        // GET: Post/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                Post post = new Post();
                post.GroupID = (int)id;
                return View(post);
            }

            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Text,Image,UserID,DateCreated, groupID")] Post post)
        {
            if (ModelState.IsValid)
            {
				var id = User.Identity.GetUserId();
				var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();
				post.UserID = user;
				post.DateCreated = DateTime.Now;  
                db.Posts.Add(post);
                db.SaveChanges();

                if (post.GroupID == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                //if (post.EventID != null)
                //{
                //    return RedirectToAction("Details", "Events", new { id = post.EventID });
                //}

                return RedirectToAction("Details", "Groups", new { id = post.GroupID });
                   
             }
                
            return View(post);
        }

        // GET: Post/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Text,Image,UserID,DateCreated")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
