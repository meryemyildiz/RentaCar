using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            // BrandTest();
            // GetCarDetailsTest();

            //ColorAddTest();
            // CarUpdateTest();

            // UserAddTest();

           // UserDeleteTest();

            UserTest();

        }

        private static void UserDeleteTest()
        {
            User user = new User();
            user.Id = 4;
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Delete(user);
        }

        private static void UserAddTest()
        {
            User user = new User();
            user.FirstName = "Songül";
            user.LastName = "Koç";
            user.Email = "s@gmail.com";
            user.Password = "123";
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.FirstName + " " + item.LastName + " " + item.Email + " " + item.Password);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorAddTest()
        {
            Color c1 = new Color();
            c1.ColorName = "Pink";
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(c1);
        }

        private static void CarUpdateTest()
        {
            Car car2 = new Car();
            car2.Id = 1;
            car2.BrandId = 1;
            car2.ColorId = 1;
            car2.ModelYear = 2017;
            car2.Description = "3.20";
            car2.DailyPrice = 400;
            CarManager carManager2 = new CarManager(new EfCarDal());
            carManager2.Update(car2);
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.ModelYear + car.BrandName + "Model" + car.ColorName + "renk aracımızın günlük fiyatı" + car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.BrandId + car.ColorId + car.DailyPrice + car.Description);
            }
        }
    }
}
