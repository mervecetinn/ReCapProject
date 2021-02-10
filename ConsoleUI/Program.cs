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
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car {Name="K",BrandId=1,DailyPrice=100,ColorId=2,ModelYear=2004 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} / {1} / {2}", car.Id, car.Name, car.ModelYear);

            }
        }
    }
}
