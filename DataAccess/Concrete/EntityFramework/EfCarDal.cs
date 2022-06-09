using Core1.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (RentaCarContext context =new RentaCarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id

                             select new CarDetailDto
                             {
                                 ModelYear = car.ModelYear,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice=car.DailyPrice
                             };
                return result.ToList();
            }
          
        }
    }
}
