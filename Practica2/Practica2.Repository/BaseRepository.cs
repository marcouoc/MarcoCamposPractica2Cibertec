using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        protected WebContextDb db;

        public int Add(T entity)
        {
            using (var db = new WebContextDb())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public int Delete(T entity)
        {
            using (var db = new WebContextDb())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges();
            }
        }

        public T GetById(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public List<T> GetList()
        {
            using (var db = new WebContextDb())
            {
                return db.Set<T>().ToList();
            }
        }
        
        public IEnumerable<T> OrderedListByDateandSize(Expression<Func<T, DateTime>> match, int size)
        {
            return db.Set<T>().OrderByDescending(match).Take(size);
        }

        public IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match, int page, int size)
        {
            return db.Set<T>().OrderByDescending(match).Page(page, size);
        }

        public int Update(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }

}
