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



		public override IDbSet<ApplicationUser> Users
		{
			get
			{
				return base.Users;
			}
			set
			{
				base.Users = value;
			}
		}
		public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends {get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<EducationInfo> EducationsInfo { get; set; }
        public DbSet<WorkInfo> WorksInfo { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<EventMember> EventMembers { get; set; }




		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}