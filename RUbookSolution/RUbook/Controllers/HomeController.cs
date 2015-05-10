using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RUbook.Models;
using RUbook.DAL;
using Microsoft.AspNet.Identity;

namespace RUbook.Controllers
{
    public class HomeController : Controller
    {
		private ApplicationDbContext db = new ApplicationDbContext();
        UserDAL userDAL;
        PostDAL postDAL;

        public HomeController() : base()
        {
            userDAL = new UserDAL(db);
            postDAL = new PostDAL(db);
        }

        [Authorize]
        public ActionResult Index()
        {
            TimelineViewModel model = new TimelineViewModel();
			
            var id = User.Identity.GetUserId();
			var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();

            model.AllPosts = postDAL.GetAllPosts(user);
            model.AllGroups = userDAL.GetAllGroups();
            model.AllEvents = userDAL.GetAllEvents();
            model.AllUsers = userDAL.GetAllUsers();
            
			//model.UserInfo = userDAL.GetUserInfo(user);

            return View(model);
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}