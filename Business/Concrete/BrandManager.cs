using Business.Abstract;
using Business.Constans;
using Business.ValidationRulesFluentValidation;
using Core.Aspects.AutoFac;
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
       [ValidationAspect(typeof(BrandValidator))]
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

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandal.Get(b => b.Id == id));
        }

        public IResult Update(Brand brand)
        {
            _brandal.Update(brand);
            return new SuccessResult(Messages.BrandsUpteted);
        }
    }
}
