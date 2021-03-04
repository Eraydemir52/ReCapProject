using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandTest();
            CarTest();
            ColorTest();
            RentalTest();
            UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success == true)
            {
                foreach (var User in result.Data)
                {
                    Console.WriteLine(User.Id + "\\" + User.FirstName + "\\" + User.LastName + "\\" + User.PasswordHash + "\\" + User.Email);
                }
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                Id = 1,
                CarId = 1,
                RentDate = new DateTime(2020),
                CustomerId = 1,
                ReturnDate = new DateTime(2021)


            }); ;
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Id + "\\" + color.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                Id = 3,
                DailyPrice = 100,
                Name = "Skoda",
                BrandId = 3,
                ModelYear = 2020,
                ColorId = 3,
                Description = "Sıfır Ayarında"

            });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Brand Id : " + brand.Id + "\nBrand Name : " + brand.Name);

                    Console.WriteLine("********************************");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    } 
}
