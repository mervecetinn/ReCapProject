using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if(CheckIfCarReturn(rental.CarId).Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }

            return new ErrorResult(Messages.CarNotReturn);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfCarReturn(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            if (result.Count == 0)
            {
                return new SuccessResult();
            }
            if (result.Count != 0)
            {
                foreach (var r in result)
                {

                    if (r.ReturnDate < DateTime.Now)
                    {
                        return new SuccessResult();
                    }
                }
            }
            
            
            return new ErrorResult();
        }
    }
}
