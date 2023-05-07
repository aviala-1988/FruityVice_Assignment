
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitVice_API_Services_Data
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> Data { get; set; }
        public DataRepository(DbContext context)
        {
            Context = context;
            Data = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
           return Data.Where(t => EF.Property<bool>(t, "IsActive"));
        }
        /// <summary>
        /// Retriveing all the data
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <param name="path3"></param>
        /// <param name="path4"></param>
        /// <returns></returns>
        public IQueryable<T> GetAll<TProperty>(System.Linq.Expressions.Expression<Func<T, TProperty>> path1, System.Linq.Expressions.Expression<Func<T, TProperty>> path2 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path3 = null, System.Linq.Expressions.Expression<Func<T, TProperty>> path4 = null)
        {
            var d = Data.Include(path1).Where(t => EF.Property<bool>(t, "IsActive"));
            if (path2 != null) d = d.Include(path2);
            if (path3 != null) d = d.Include(path3);
            if (path4 != null) d = d.Include(path4);
            return d;
        }

        /// <summary>
        /// Get With No Tracking
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllWithNoTracking()
        {
            return Data.Where(t => EF.Property<bool>(t, "IsActive")).AsNoTracking<T>();
            // return Data;
        }

        public DbSet<T> GetUnderlyingContextData()
        {
            return Data;
        }

        /// <summary>
        /// Save data to database
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            Data.Add(entity);
        }

        /// <summary>
        /// Save data to database
        /// </summary>
        /// <param name="entities">Expects collection type parameter</param>
        public void AddRange(IEnumerable<T> entities)
        {
            Data.AddRange(entities);
        }

        /// <summary>
        /// Removeing data from database
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            Data.Remove(entity);
        }

        /// <summary>
        ///  Removing data from database
        /// </summary>
        /// <param name="entities">Expects collection type parameter</param>
        public void Delete(IEnumerable<T> entities)
        {
            Data.RemoveRange(entities);
        }
        /// <summary>
        /// Updating to database 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            Data.Update(entity);
        }

        public IQueryable<T> GetAllData()
        {
            return Data;
        }
    }
}
