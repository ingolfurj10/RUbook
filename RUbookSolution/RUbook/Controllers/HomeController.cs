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
        GroupDAL groupDAL;
        EventDAL eventDAL;

        public HomeController() : base()
        {
            userDAL = new UserDAL(db);
            postDAL = new PostDAL(db); 
            groupDAL = new GroupDAL(db);
            eventDAL = new EventDAL(db);
        }

        [Authorize]
        public ActionResult Index()
        {
            TimelineViewModel model = new TimelineViewModel();

            var userId = User.Identity.GetUserId();
            var user = userDAL.GetUser(userId);
           

            try
            {
                var friends = (from u in db.Friends where u.UserId.Id == user.Id select u.FriendUserID.Id).ToList();
                friends.Add(userId);

                model.AllPosts = postDAL.GetAllPosts(friends);
                model.AllGroups = groupDAL.GetAllGroups();
                model.AllEvents = eventDAL.GetAllEvents();
                model.AllUsers = userDAL.GetAllUsers();
                model.User = userDAL.GetUser(userId);
                model.AllFriendsOfUser = userDAL.AllFriendsOfUser(userId);
                model.AllGroupsOfUser = groupDAL.GetAllGroupsOfUser(userId);
                model.AllEventsOfUser = eventDAL.GetAllEventsOfUser(userId);

                return View(model);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return null; 
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