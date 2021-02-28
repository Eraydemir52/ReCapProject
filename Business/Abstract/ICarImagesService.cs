using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetById(int id);
        IResult Add(Image ımage,CarImages carImages);
        IResult Update(Image ımage,CarImages carImages);
        IResult Delete(Image ımage,CarImages carImages);
    }
}
