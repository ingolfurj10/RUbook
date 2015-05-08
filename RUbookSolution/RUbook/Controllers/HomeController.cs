using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RUbook.Models;
using RUbook.DAL;

namespace RUbook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TimelineViewModel model = new TimelineViewModel();

            UserDAL userDAL = new UserDAL();
            model.AllPosts = userDAL.GetAllPosts();
            model.AllGroups = userDAL.GetAllGroups();
            model.AllEvents = userDAL.GetAllEvents();

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