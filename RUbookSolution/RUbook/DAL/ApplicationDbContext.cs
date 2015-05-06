using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RUbook.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RUbook.DAL
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<Post> Posts { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}