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
        public BlondsCookingContext() : base("AzureConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlondsCookingContext, Migrations.Configuration>("AzureConnection"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }  
    }
}