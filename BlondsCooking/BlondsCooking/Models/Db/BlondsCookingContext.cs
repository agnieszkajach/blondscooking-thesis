using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Models.Db
{
    public class BlondsCookingContext : DbContext
    {
        public BlondsCookingContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlondsCookingContext, Migrations.Configuration>("DefaultConnection"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }  
    }
}