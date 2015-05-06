using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RUbook.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RUbook.DAL
{
    public class PostContext: DbContext
    {

        public PostContext()
            : base("NewContext")
        {

        }

        public DbSet<PostContext> Post { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}