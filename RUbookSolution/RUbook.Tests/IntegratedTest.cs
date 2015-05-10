using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUbook.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using RUbook.Controllers;
using RUbook.Models;

namespace RUbook.Tests
{
	[TestClass]
	public class IntegratedTest
	{
		[TestMethod]
		public void Befriend()
		{
			var context = new ApplicationDbContext();

			var query = (from u in context.Users select u).First();

			Assert.AreEqual(query.Email, "bla@bla.is");
		}

		[TestMethod]
		public void CreatePost()
		{
			var controller = new PostController();

			var user = (from u in controller.db.Users where u.Id == "Id"  select u).First();
			var post = new Post(){UserID=(ApplicationUser)user,Text="This will work"};
			controller.Create(post);
		}
	}
}
