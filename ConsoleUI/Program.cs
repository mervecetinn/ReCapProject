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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CarDetailsTest();
            //ListCarsTest();
            RentCarTest();
        }

        private static void RentCarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 9, CustomerId = 3, RentDate = DateTime.Now });
            Console.WriteLine(result.Success + "--" + result.Message);
        }

        private static void ListCarsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Name);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0}-{1}-{2}", car.CarName, car.BrandName, car.ColorName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 11, ColorName = "Yellow" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + color.ColorName);

            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 7, BrandName = "Porsche" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + brand.BrandName);

            }
            Console.WriteLine(brandManager.GetById(1).Data.BrandName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Name = "K", BrandId = 1, DailyPrice = 100, ColorId = 2, ModelYear = 2004 });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1} / {2}", car.Id, car.Name, car.ModelYear);

            }
        }
    }
}
