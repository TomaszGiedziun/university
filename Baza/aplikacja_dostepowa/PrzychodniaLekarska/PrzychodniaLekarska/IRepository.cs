using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PrzychodniaLekarska
{
    public interface IRepository<T> where T : class, IDBEntity
    {
        void Add(T entity);
        int AddAndReturnId(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id, params Expression<Func<T, object>>[] includeItems);
        List<T> Find(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems);
        bool Any(Func<T, bool> filter, params Expression<Func<T, object>>[] includeItems);
        List<T> FindAll(params Expression<Func<T, object>>[] includeItems);
        //PagedData<T> FindAll(Func<T, bool> filter, Func<T, object> order, bool? desc, int page, int perPage, params Expression<Func<T, object>>[] includeItems);
    }
}