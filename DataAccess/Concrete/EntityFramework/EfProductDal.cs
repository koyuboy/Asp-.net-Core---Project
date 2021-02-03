using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {   //IDispossable pattern implemantation of C#
            using (NorthwindContext context = new NorthwindContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var addedEntity = context.Entry(entity); //referansı yakalar
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            } 
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var deletedEntity = context.Entry(entity); //referansı yakalar
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); //select * from products : filtrelenmiş select
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) // bu yapı blok bitince oluşturulan objeyi hafızadan siler
            {
                var updatedEntity = context.Entry(entity); //referansı yakalar
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
