using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{Id=1,BrandId=1,ColorId=1,DailyPrice=100000,Description="Bmw",ModelYear=2011},
                new Product{Id=2,BrandId=2,ColorId=2,DailyPrice=200000,Description="Audi",ModelYear=2015},
                new Product{Id=3,BrandId=3,ColorId=3,DailyPrice=300000,Description="Skoda",ModelYear=2016},
                new Product{Id=4,BrandId=4,ColorId=4,DailyPrice=400000,Description="Opel",ModelYear=2019}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productTODelete = _products.SingleOrDefault(X => X.Id==product.Id);
            _products.Remove(productTODelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Product product)
        {
            return _products.Where(p => p.Id == product.Id).ToList();
        }

        

        public void GetById(Product product)
        {
           
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(Y => Y.Id == product.Id);
            productToUpdate.Id = product.Id;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
            productToUpdate.ModelYear = product.ModelYear;
        }

        void IProductDal.GetAll(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
