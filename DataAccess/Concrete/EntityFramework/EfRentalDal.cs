using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (ReCarContext carContext = new ReCarContext())
            { 

                // equals  ==
                var result = from renta in carContext.Rentals
                             join custo in carContext.Customers
                             on renta.CustomerId equals custo.CustomerId

                             join use in carContext.Users
                             on custo.UserId equals use.UserId

                             join car in carContext.Cars
                             on renta.CarId equals car.CarId

                             join brand in carContext.Brands
                             on car.BrandId equals brand.BrandId

                             select new RentalDetailDto
                             {
                                 RentalId = renta.RentalId,
                                 BrandName = brand.BrandName,
                                 FirstName = use.FirstName,
                                 LastName = use.LastName,
                                 RentDate = renta.RentDate,
                                 ReturnDate = renta.ReturnDate
                             };

                return result.ToList();
                             
            }
        
        }
    }

}
