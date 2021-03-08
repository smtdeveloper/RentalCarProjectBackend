using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car entity)
        {
            if (entity.Name.Length >= 2 && entity.DailyPrice > 0 )
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.SuccessAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalInvalid);
                //Console.WriteLine("Gerekli şartlara uygun değil!");
            }

           

        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);

            return new SuccessResult(Messages.SuccessDeleted);
        }


        public IDataResult<List<Car>>  GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>>  GetAllByBrandId(int id)
        {
            return new   SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id)); 
        }

        public IDataResult<List<Car>>  GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>>  GetById(int entityId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == entityId));
        }

        public IDataResult<List<CarDetailDto>>  GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);

            return new SuccessResult(Messages.SuccessUpdated);

        }
    }
}
