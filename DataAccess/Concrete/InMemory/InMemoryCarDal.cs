using Core.DataAccess.EntityFramework;
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

            new Car{ CarId = 1 , BrandId = 1, ColorId = 1 , DailyPrice = 50000, ModelYear = 2021, Description = " Sıfır "},
            new Car{ CarId = 2 , BrandId = 1, ColorId = 2 , DailyPrice = 60000, ModelYear = 2019, Description = " 2. El "},
            new Car{ CarId = 3 , BrandId = 2, ColorId = 2 , DailyPrice = 30000, ModelYear = 2008, Description = " 2. El "},
            new Car{ CarId = 4 , BrandId = 3, ColorId = 3 , DailyPrice = 10000, ModelYear = 2019, Description = " Sıfır "},
            new Car{ CarId = 5 , BrandId = 3, ColorId = 4 , DailyPrice = 90000, ModelYear = 2020, Description = " 2. El "}

            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            
            _cars.Remove(carToDelete);
        }

        public List<Car> Get()
        {
            throw new NotImplementedException();
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
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

        public List<Car> GetById(int car)
        {
            return _cars.Where(c => c.CarId == car).ToList(); // listeleme yapar
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
           
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
