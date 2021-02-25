using Business.Abstract;
using Business.Constans;
using Business.ValidationRulesFluentValidation;
using Core.Aspects.AutoFac;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(CarImages carImages)
        {
           IResult result= BusinessRule.Run(CheckImageLimit(carImages.Id));
            if (result !=null)
            {
                return result;
            }
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }
        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.Id == id));
        }

      

        public IResult Update(CarImages carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        public IResult Delete(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);

        }
        private IResult CheckImageLimit(int id)
        {
            var result = _carImagesDal.GetAll(p => p.Id == id).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }
            return new SuccessResult();
        }
    }
}
