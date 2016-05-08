using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PrzychodniaLekarska
{
    public class Repository<T> : IRepository<T> where T : class, IDBEntity
    {
        public void Add(T entity)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public int AddAndReturnId(T entity)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                context.Entry(entity).GetDatabaseValues();
                return entity.ID;
            }
        }

        public void Update(T entity)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                entity.IsDeleted = true;
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public T FindById(int id, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.FirstOrDefault(x => x.ID == id && !x.IsDeleted);
            }
        }

        public List<T> Find(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.Where(x => !x.IsDeleted).Where(filter).ToList();
            }
        }

        public bool Any(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.Where(x => !x.IsDeleted).Where(filter).Any();
            }
        }

        public List<T> FindAll(params Expression<Func<T, object>>[] includeItems)
        {
            using (var context = new PrzychodniaLekarskaContext())
            {
                var result = context.Set<T>() as IQueryable<T>;
                foreach (var include in includeItems)
                {
                    result = result.Include(include);
                }
                return result.Where(x => !x.IsDeleted).ToList();
            }
        }

        //public PagedData<T> FindAll(Func<T, bool> filter, Func<T, object> order, bool? desc, int page, int pageSize, params Expression<Func<T, object>>[] includeItems)
        //{
        //    using (var context = new PrzychodniaLekarskaContext())
        //    {
        //        var result = context.Set<T>() as IQueryable<T>;
        //        foreach (var include in includeItems)
        //        {
        //            result = result.Include(include);
        //        }
        //        result = result.Where(x => !x.IsDeleted);
        //        var result2 = result.Where(filter);
        //        var count = result2.Count();
        //        return new PagedData<T>(result2, order, desc, page, pageSize, count);
        //    }
        //}
    }
}