using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            //  equals == karsılaştırma yapar
            using (ReCarContext carContext = new ReCarContext())
            {
                var result = from car in carContext.Cars
                             join color in carContext.Colors
                             on car.ColorId equals color.ColorId

                             join brand in carContext.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 Id = car.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 Name = car.Name


                             };
                return result.ToList();

            }
        }
    }
}
