using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FarmFresh.DBContext
{
    public class FarmFreshDBContext : DbContext
    {
        static FarmFreshDBContext()
        {
            Database.SetInitializer<FarmFreshDBContext>(null);
        }

        public FarmFreshDBContext() :base("Name=myconnection")
        { }

        public DbSet<Product> ProductSet { get; set; }
        

        /*public DbSet<Test> TestSet { get; set; }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>().HasKey<int>(e => e.ID);
           
        }

    }
}