using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core1.Aspects.Autofac.Validation;
using Core1.CrossCuttingConcerns.Validations;
using Core1.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
         
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 14)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public   IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.CarListed);
        }

        public IDataResult< List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
