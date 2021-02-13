using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkUse;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfCustomerDal: EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
    }
}
