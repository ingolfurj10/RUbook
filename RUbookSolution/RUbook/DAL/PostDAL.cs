using RUbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUbook.DAL
{
    public class PostDAL
    {
        private static ApplicationDbContext db;

        public PostDAL(ApplicationDbContext context)
        {
            db = context;
        }

        private static PostDAL instance;

        public static PostDAL Instance
        {
            get
            {
                if (instance == null)
                    
                    instance = new PostDAL(db);
                    return instance;
            }
        }

        public List<Post> GetAllPosts(List<string> uid)
        {
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

        

        public Post GetPostById(int postId)
        {
            Post result = (from post in db.Posts
                           where post.ID == postId
                           select post).FirstOrDefault();
            if(result != null)
            {
                result.Comments = (from comment in db.Comments
                                   where comment.ID == result.ID
                                   orderby comment.CreatedDate ascending
                                   select comment).ToList();
            }
            return result;
        }

        public void AddComment(Comment comment)
        {
            int newID = 1;
            if (db.Comments.Count() > 1)
            {
                newID = db.Comments.Max(x => x.ID) + 1;
            }
            comment.ID = newID;
            comment.CreatedDate = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
        }
    }
}