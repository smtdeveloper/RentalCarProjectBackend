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

                                                
                                                   
                                                  select new CarDetailDto
                                                  {
                                                      CarId = car.CarId,
                                                      BrandName = brand.BrandName,
                                                      ColorName = color.ColorName,
                                                      DailyPrice = car.DailyPrice,
                                                      Description = car.Description,
                                                      ModelYear = car.ModelYear,
                                                      Name = car.ModelName,
                                                      ImagePath = (from carImage in carContext.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault(),
                                                      //BUNU BÖYLE ALABİLİRSİN DİĞER TÜRLÜ HATA VERİR SQL DE DE DATE DEĞİŞRİREYİMMİ YOK BUNUN ONLA İLİŞKİSİ YOK BU DTO TARAFI 
                                                      CarImageDate = (from carImage in carContext.CarImages where carImage.CarId == car.CarId select carImage.Date).ToString()
                                                      //CarImageDate = (from carImage in context.CarImages where carImage.CarId == c.CarId select carImage.Date).FirstOrDefault().Da
                                                  }; //IQueryable<CarDetailDto>

                return result.ToList();
            }
            //carımagepath onu da burdan çekiyorsun 
        }
    }
}


