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
    class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (CarProjectContext context=new CarProjectContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return filter == null ? context.Set<Category>().ToList()
                    : context.Set<Category>().Where(filter).ToList();
            }

        }

        public void GetAll(Category entity)
        {
           
        }

        

        public void GetById(Category entity)
        {
            
        }

        public void Update(Category entity)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
