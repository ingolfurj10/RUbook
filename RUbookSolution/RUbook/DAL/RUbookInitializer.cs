using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RUbook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace RUbook.DAL
{
	public class RUbookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
        protected override void Seed(ApplicationDbContext context)
		{
			//var users = new List<ApplicationUser>()
			//{
			//	new ApplicationUser{Email="blabla@eitthvad.com",PasswordHash="1"}
			//};

			//users.ForEach(u => appliContext.Users.Add(u));
			//appliContext.SaveChanges();

            
			var posts = new List<Post>()
			{
				new Post{DateCreated=System.DateTime.Now,userID="blabla@eitthvad.com",text="foobar"}
			};

			posts.ForEach(p => context.Posts.Add(p));
			context.SaveChanges();
		}
	}
}