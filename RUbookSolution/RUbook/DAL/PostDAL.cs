using RUbook.Models;
using RUbook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

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

        /// <summary>
        /// Gets all posts that connects to the id's(list) from the input and are not 
        /// connected to group or event. Used to get post to display on the timeline but not
        /// the group and event posts
        /// </summary>
        /// <param name="uid">users id's</param>
        /// <returns></returns>
        public List<Post> GetUsersPosts(List<string> uid)
        {
            try
            {
                var posts = db.Posts.Where(p => uid.Contains(p.UserID.Id))
                                    .Where(p => p.GroupID == null)
                                    .Where(p => p.EventID == null)
                                    .OrderByDescending(p => p.DateCreated)
                                    .Take(25)
                                    .ToList();
                return posts;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        
        /// <summary>
        /// Gets a post by certain id from the input
        /// </summary>
        /// <param name="postId">post id</param>
        /// <returns></returns>
        public Post GetPostById(int postId)
        {
            Post result = (from post in db.Posts
                           where post.ID == postId
                           select post).FirstOrDefault();

            if(result != null)
            {
                result.Comments = (from comment in db.Comments
                                   where comment.PostID == result.ID
                                   orderby comment.CreatedDate ascending
                                   select comment).ToList();
            }
            return result;
        }

      /// <summary>
      /// Creates new comment and sets the date to the current date and time
      /// </summary>
      /// <param name="comment"></param>
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

        /// <summary>
        /// Gets all group post that connects to the group the the id from the input
        /// </summary>
        /// <param name="guid">groupId</param>
        /// <returns></returns>
        public List<Post> GetGroupPosts(int? guid)
        { 
            if (guid == null)
            {
                return null;
            }

            var posts = db.Posts.Where(p => p.GroupID == (int)guid)
                                .OrderByDescending(p => p.DateCreated)
                                .ToList();

            return posts;
        }
        /// <summary>
        /// Gets all group post that connects to the group the the id from the input
        /// </summary>
        /// <param name="evid">eventId</param>
        /// <returns></returns>
        public List<Post> GetEventPosts(int? evid)
        {
            if (evid == null)
            {
                return null;
            }
            var posts = db.Posts.Where(p => p.EventID == (int)evid)
                                .OrderByDescending(p => p.DateCreated)
                                .ToList();
            return posts;
        }
    }
}