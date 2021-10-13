using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Entities : DbContext
    {
        public Entities() : base("MyDB")
        {
        }
        public DbSet<admin> admins { get; set; }
        public DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<admin>().ToTable("admins");
            modelBuilder.Entity<product>().ToTable("products");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}