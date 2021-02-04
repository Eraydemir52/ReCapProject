using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IGetCarsByColorId
    {
        List<Color> GetAll();
        List<Color> GetAllByColorId(int id);
        
    }
}
