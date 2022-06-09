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
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=20000,Description="Sahibinden temiz araç" },
            new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2008,DailyPrice=15000,Description="Hasarsız araç" },
            new Car{Id=3,BrandId=2,ColorId=1,ModelYear=2005,DailyPrice=12000,Description="Konforlu araç" },
            new Car{Id=4,BrandId=2,ColorId=2,ModelYear=2003,DailyPrice=11000,Description="Araç" }
              };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
                Car carsToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(ctu => ctu.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
        }
    }
}
