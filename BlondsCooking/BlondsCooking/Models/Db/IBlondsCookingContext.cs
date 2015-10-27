﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlondsCooking.Models.Db
{
    public interface IBlondsCookingContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void AddOrUpdate<T>(T entity) where T : class;
        void SaveChanges();
    }
}
