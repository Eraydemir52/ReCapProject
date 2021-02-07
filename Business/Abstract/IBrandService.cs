using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IBrandService
    {
        List<Brand> GetAll();
        List<Brand> GetAllByBrandrId(int id);
        List<Brand> GetAllByUnitPrice(decimal min, decimal max);

    }
}
