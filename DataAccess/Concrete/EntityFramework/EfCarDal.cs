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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            //  equals == karsılaştırma yapar
            using (ReCarContext carContext = new ReCarContext())
            {
                IQueryable<CarDetailDto> result = from car in filter is null ? carContext.Cars : carContext.Cars.Where(filter)
                                                  join color in carContext.Colors
                                                  on car.ColorId equals color.ColorId

                                                  join brand in carContext.Brands
                                                  on car.BrandId equals brand.BrandId

                                                  join image in carContext.CarImages
                                                  on car.CarId equals image.CarId
                                                   
                                                  select new CarDetailDto
                                                  {
                                                      CarId = car.CarId,
                                                      BrandName = brand.BrandName,
                                                      ColorName = color.ColorName,
                                                      DailyPrice = car.DailyPrice,
                                                      Description = car.Description,
                                                      ModelYear = car.ModelYear,
                                                      Name = car.ModelName,
                                                      CarImageDate = image.Date,
                                                      ImagePath = image.ImagePath
                                                      //CarImageDate = (from carImage in context.CarImages where carImage.CarId == c.CarId select carImage.Date).FirstOrDefault().Da
                                                  }; //IQueryable<CarDetailDto>
                return result.ToList();

            }
        }
    }
}


