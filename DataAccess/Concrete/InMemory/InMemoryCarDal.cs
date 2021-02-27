using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {

            new Car{ Id = 1 , BrandName = " Pejo 307 ", ColorId = 1 , DailyPrice = 50000, ModelYear = 2021, Description = " Sıfır "},
            new Car{ Id = 2 , BrandName = " Opel Astra ", ColorId = 2 , DailyPrice = 60000, ModelYear = 2019, Description = " 2. El "},
            new Car{ Id = 3 , BrandName = " BMW ", ColorId = 2 , DailyPrice = 30000, ModelYear = 2008, Description = " 2. El "},
            new Car{ Id = 4 , BrandName = " Pejo Patner ", ColorId = 3 , DailyPrice = 10000, ModelYear = 2019, Description = " Sıfır "},
            new Car{ Id = 5 , BrandName = " Reneo Clıo ", ColorId = 4 , DailyPrice = 90000, ModelYear = 2020, Description = " 2. El "}

            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int car)
        {
            return _cars.Where(c => c.Id == car).ToList(); // listeleme yapar
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
           
        }
    }
}
