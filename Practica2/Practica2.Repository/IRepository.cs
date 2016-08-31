﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Practica2.Model;

namespace Practica2.Repository
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        List<T> GetList();
        //id generico
        T GetById(Expression<Func<T, bool>> match);
      
        IEnumerable<T> OrderedListByDateandSize(Expression<Func<T, DateTime>> match, int size);

        IEnumerable<T> PaginatedList(Expression<Func<T, DateTime>> match, int page, int size);
    }
}
