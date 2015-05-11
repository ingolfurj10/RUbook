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

        public List<Post> GetAllPosts(List<string> uid)
        {

            //var posts = db.Posts.OrderByDescending(p => p.DateCreated).ToList();
            try
            {
                var posts = db.Posts.Where(p => uid.Contains(p.UserID.Id)).OrderByDescending(p => p.DateCreated).ToList();
                
                return posts;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;

            
       
        }
    }
}