using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars = new List<Car>()
        {
            new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=150,Description=" ",ModelYear=2010},
            new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=450,Description=" ",ModelYear=2015},
            new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=350,Description=" ",ModelYear=2007},
            new Car{Id=4,BrandId=2,ColorId=2,DailyPrice=200,Description=" ",ModelYear=2018},
            new Car{Id=5,BrandId=3,ColorId=2,DailyPrice=500,Description=" ",ModelYear=2019}
        };
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = cars.SingleOrDefault(c=>c.Id==car.Id);
            cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
