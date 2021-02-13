using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkUse;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfBrandDal: EfEntityRepositoryBase<Brand, NorthwindContext>, IBrandDal
    {
    }
}
