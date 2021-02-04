using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product :IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }

        public int DailyPrice { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; } //para birimi



    }
}
