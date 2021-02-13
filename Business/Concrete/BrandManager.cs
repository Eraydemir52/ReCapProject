using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length<2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandal.GetAll(), Messages.BrandsListed);
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult(Messages.BrandsUpteted);
        }
    }
}
