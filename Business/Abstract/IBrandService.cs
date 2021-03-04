using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IBrandService
    {
        //List<Brand> GetAll();
        //List<Brand> GetAllByBrandrId(int id);
        //List<Brand> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IResult AddTransactionalTest(Product product);//bir hata olursa geri işlemi geri alır

    }
}
