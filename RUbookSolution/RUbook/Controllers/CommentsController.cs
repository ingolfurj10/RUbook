using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RUbook.Models;
using RUbook.DAL;
using Microsoft.AspNet.Identity;

namespace RUbook.Controllers
{
    public class CommentsController : Controller
    {
		private ApplicationDbContext db = new ApplicationDbContext();
		UserDAL userDAL;
		PostDAL postDAL;  
        
     	public CommentsController() : base()
		{
			userDAL = new UserDAL(db);
			postDAL = new PostDAL(db);            
		}

        public ActionResult CommentOnPost(FormCollection collection)
        {
            string postId = collection["postid"];
            string commentText = collection["posttext"];

            if (String.IsNullOrEmpty(postId))
            {
                return View("Error");
            }
            if (String.IsNullOrEmpty(commentText))
            {
                return RedirectToAction("Details", "Post", new { id = postId });
            }

			var user = userDAL.GetUser(User.Identity.GetUserId());
            int id = Int32.Parse(postId);
            Post post = postDAL.GetPostById(id);
            if (post != null)
            {
				Comment comment = new Comment { Text = commentText, PostID = post.ID, UserID = user };
                postDAL.AddComment(comment);
                return RedirectToAction("Details", "Post", new { id = postId });
            }
            return View("Error");
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
