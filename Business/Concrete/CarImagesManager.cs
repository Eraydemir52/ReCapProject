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
        private ICarImagesDal _carImageDal;

        public CarImagesManager(ICarImagesDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

       

        public IDataResult<List<CarImages>> GetById(int id)
        {
            return GetByIdMetod(id);

        }

       

        public IResult Add(Image image, CarImages carImage)
        {

            IResult result = BusinessRule.Run(CheckLimetedError(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            return AddMetod(image, carImage);
        }

      

        public IResult Delete(Image ımage,CarImages carImage)
        {
            return DeleteMetod(carImage);
        }

       

        public IResult Update(Image image, CarImages carImage)
        {
            return UpdateMetod(image, carImage);
        }












      //*****************METODLAR********************************//
      

        private IResult CheckLimetedError(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }
            return new SuccessResult();
        }
        private IResult AddMetod(Image image, CarImages carImage)
        {
            string path = Environment.CurrentDirectory + "\\wwwroot" + "\\Images\\";
            string randomName = null;
            string type = null;


            if (image.Files != null && image.Files.Length > 0)
            {
                randomName = Guid.NewGuid().ToString();
                type = Path.GetExtension(image.Files.FileName);

                if (type != ".jpeg" && type != ".png" && type != ".jpg")
                {
                    return new ErrorResult("Wrong file type.");
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fs = File.Create(path + randomName + type))
                {
                    image.Files.CopyTo(fs);
                    fs.Flush();
                    carImage.ImagePath = (path + randomName + type).Replace("\\", "/");
                    carImage.Date = DateTime.Now;
                }

                _carImageDal.Add(carImage);
                return new SuccessResult("Car image added");
            }

            return new ErrorResult("File doesn't exists.");
        }
        private IResult DeleteMetod(CarImages carImage)
        {
            var images = _carImageDal.Get(c => c.Id == carImage.Id);
            if (images == null)
            {
                return new ErrorResult("Image not found");
            }

            var path = "wwwroot" + images.ImagePath;

            if (File.Exists(path.Replace("/", "\\")))
            {
                File.Delete(path.Replace("/", "\\"));
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }
        private IResult UpdateMetod(Image image, CarImages carImage)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var imagePathh = "wwwroot" + isImage.ImagePath;

            if (File.Exists(imagePathh.Replace("/", "\\")))
            {
                File.Delete(imagePathh.Replace("/", "\\"));
            }

            var path = "\\Images\\";
            var currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            string randomName = null;
            string type = null;

            if (image.Files != null && image.Files.Length > 0)
            {
                randomName = Guid.NewGuid().ToString();
                type = Path.GetExtension(image.Files.FileName);

                if (!Directory.Exists(currentDirectory + path))
                {
                    Directory.CreateDirectory(currentDirectory + path);
                }

                if (type != ".jpeg" && type != ".png" && type != ".jpg")
                {
                    return new ErrorResult("Wrong file type.");
                }

                using (FileStream fs = System.IO.File.Create(currentDirectory + path + randomName + type))
                {
                    image.Files.CopyTo(fs);
                    fs.Flush();
                    carImage.ImagePath = (path + randomName + type).Replace("\\", "/");
                    carImage.Date = isImage.Date;
                }

                _carImageDal.Update(carImage);
                return new SuccessResult("Car image updated");
            }
            return new ErrorResult("File doesn't exists");
        }
        private IDataResult<List<CarImages>> GetByIdMetod(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImages>>(result);
            }

            List<CarImages> images = new List<CarImages>();
            images.Add(new CarImages() { CarId = 0, Id = 0, Date = DateTime.Now, ImagePath = "/images/car-rent.png" });

            return new SuccessDataResult<List<CarImages>>(images);
        }




    }
}
