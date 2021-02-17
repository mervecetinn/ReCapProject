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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}-{1}-{2}",car.CarName,car.BrandName,car.ColorName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 11, ColorName = "Yellow" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + color.ColorName);

            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 7, BrandName = "Porsche" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + brand.BrandName);

            }
            Console.WriteLine(brandManager.GetById(1).BrandName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Name = "K", BrandId = 1, DailyPrice = 100, ColorId = 2, ModelYear = 2004 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} / {1} / {2}", car.Id, car.Name, car.ModelYear);

            }
        }
    }
}
