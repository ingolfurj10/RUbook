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
                //get the users id that a user is following + his own so we
                //can post the right posts on the timeline
                var friends = userDAL.GetAllFriendsIds(userId);
                friends.Add(userId);

                model.Posts = postDAL.GetUsersPosts(friends);
                model.User = userDAL.GetUser(userId);
                model.MyFriends = userDAL.GetFriends(userId);
                model.MyGroups = groupDAL.GetAllGroupsOfUser(userId);
                model.MyEvents = eventDAL.GetAllEventsOfUser(userId);

                return View(model);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return null; 
        }
    }
}