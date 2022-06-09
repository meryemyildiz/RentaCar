﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core1.DataAccess
{
   public interface IEntityRepository<T>where T:class,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        List<T> GetById(int id);
    }
}
