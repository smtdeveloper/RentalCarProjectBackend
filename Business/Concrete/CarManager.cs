using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.CrossCuttingConcerns.Validation;
using Core.Utilities;
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
        public IResult Add(Car entity)
        {
            //business codes (İş Kodları)
            _carDal.Add(entity);
            return new ErrorResult(Messages.RentalInvalid);
          
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);

            return new SuccessResult(Messages.SuccessDeleted);
        }


        public IDataResult<List<Car>>  GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<List<Car>>  GetAllByBrandId(int id)
        {
            return new   SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.SuccessListed); 
        }

        public IDataResult<List<Car>>  GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.SuccessListed);
        }

        public IDataResult<List<Car>>  GetById(int entityId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == entityId), Messages.SuccessListed);
        }

        public IDataResult<List<CarDetailDto>>  GetCarDetailDtos()
        {

            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.SuccessListed);

        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);

            return new SuccessResult(Messages.SuccessUpdated);

        }
    }
}
