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

        [Authorize]
        public ActionResult Index()
        {
            TimelineViewModel model = new TimelineViewModel();
			var id = User.Identity.GetUserId();
			var user = (from u in db.Users where u.Id == id select u).SingleOrDefault();

            UserDAL userDAL = new UserDAL();
            model.AllPosts = userDAL.GetAllPosts();
            model.AllGroups = userDAL.GetAllGroups();
            model.AllEvents = userDAL.GetAllEvents();
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