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
    class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (CarProjectContext  context = new CarProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return filter == null ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();


            }

        }

      

        public void Update(Product entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
           
        }
    }
}
