using RUbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.DAL
{
    public class PostDAL
    {
        private ApplicationDbContext db;

        public PostDAL(ApplicationDbContext context)
        {
            db = context;
        }

        public List<Post> GetAllPosts(ApplicationUser User)
        {

			//var posts = db.Posts.OrderByDescending(p => p.DateCreated).ToList();
            var posts = db.Posts.Where(p => p.UserID.Id == User.Id).OrderByDescending(p => p.DateCreated).ToList();

            return posts;
       
        }
    }
}