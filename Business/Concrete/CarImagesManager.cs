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
using System.IO;
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
        public IResult Add(Image image,CarImages carImages)
        {
           IResult result= BusinessRule.Run(CheckImageLimit(carImages.CarId));
            if (result !=null)
            {
                return result;
            }

            var newImage = CreatFile(image, carImages).Data;
            _carImagesDal.Add(newImage);
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

      

        public IResult Update(Image image,CarImages carImages)
        {
            var newImage = UpdateFile(image, carImages).Data;
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }

        public IResult Delete(Image ımage,CarImages carImages)
        {
            DeleteFile(carImages);
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);

        }
        private IResult CheckImageLimit(int id)
        {
            var result = _carImagesDal.GetAll(p => p.CarId == id).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }
            return new SuccessResult();
        }
        private   IDataResult<CarImages> CreatFile(Image image,CarImages carImages)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");
            if (image.Files==null)
            {
                carImages.ImagePath = ("\\defult_img.png").Replace("\\", "/");
            }
            else
            {
                string extension = Path.GetExtension(image.Files.FileName);
                string guid = Guid.NewGuid().ToString() + DateTime.Now.Millisecond + "_" + DateTime.Now.Hour + extension + "_" + DateTime.Now.Minute;

                using (FileStream fileStream =System.IO.File.Create(path+guid+extension))
                {
                    image.Files?.CopyTo(fileStream);
                    fileStream.Flush();
                    carImages.ImagePath = (guid + extension).Replace("\\", "/");
                }



            }
            carImages.Date = DateTime.Now;
            return new SuccessDataResult<CarImages>(carImages);
        }
        private IResult DeleteFile(CarImages carImages)
        {
            var result = _carImagesDal.Get(c => c.Id == carImages.Id);
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\");
            try
            {
                File.Delete(path + result.ImagePath);
            }
            catch ( Exception)
            {

                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<CarImages> UpdateFile(Image image,CarImages carImages)
        {
            DeleteFile(carImages);
            var newImage = CreatFile(image, carImages).Data;
            return new SuccessDataResult<CarImages>(newImage);
        }
    }
}
