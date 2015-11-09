using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Models.Db
{
    public class BlondsCookingContext : DbContext, IBlondsCookingContext
    {
        public BlondsCookingContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlondsCookingContext, Migrations.Configuration>("DefaultConnection"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public void AddOrUpdate<T>(T entity) where T : class
        {
            Set<T>().AddOrUpdate(entity);
        }

        void IBlondsCookingContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}