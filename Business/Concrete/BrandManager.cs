using Business.Abstract;
using Business.BusinessAspect;
using Business.Constans;
using Business.ValidationRulesFluentValidation;
using Core.Aspects.AutoFac;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandal = brandDal;
        }
       [SecuredOperation("admin.add")]//(küçük harf çalış)
       [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Brand brand)
        {
            
            _brandal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

       

        public IResult Delete(Brand brand)
        {
            _brandal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(5)]//Bu kodun çalışma sı 5 snyi geçerse beni uyar!
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandal.GetAll(), Messages.BrandsListed);
        }
        [CacheAspect]//yeni ürün ekler veya güncelerse onu cache den getirmez
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandal.Get(b => b.Id == id));
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Brand brand)
        {
            _brandal.Update(brand);
            return new SuccessResult(Messages.BrandsUpteted);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
