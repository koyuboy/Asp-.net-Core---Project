using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //T ye sadece class yazılabilir demek , sadece referans yani, int yazılamaz
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new() //ya IEntity yada bundan türemiş olmalı
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
