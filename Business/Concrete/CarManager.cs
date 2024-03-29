﻿using Business.Abstract;
using Business.BussinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

       
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

       [ValidationAspect(typeof(CarValidator))]
       [SecuredOperation("product.add,admin,moderator")]
       [CacheRemoveAspect("ICarSercive.Get")]
        public IResult Add(Car entity)
        {

           IResult result = BusinessRules.Run(CheckİfCarBrand(entity.BrandId));

            if (!result.Success)
            {
                return result;
            }

            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactinaolTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;  
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);

            return new SuccessResult(Messages.SuccessDeleted);
        }

        // key = Business.Concrete.CarManager.GetAllByColorId(1)   // Paremetli  olan'da
        // key = Business.Concrete.CarManager.GetAll      // Paremetsiz olan'da :)


       
       
        public IDataResult<List<Car>>  GetAll()
        {
            //if (DateTime.Now.Hour ==5)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.SuccessListed);
        }


        
        public IDataResult<List<CarDetailDto>>  GetAllByBrandId(int id)
        {
            return new   SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id), Messages.SuccessListed);
         // return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<CarDetailDto>>  GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == id), Messages.SuccessListed);
        }


        [CacheAspect]  // key , Value
        [PerformanceAspect(5)]
        public IDataResult<List<Car>>  GetById(int entityId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == entityId), Messages.SuccessListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId), Messages.SuccessListed);
        }

       

       
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);

        }


        private IResult CheckİfCarBrand(int branId)
        {
            int result = _carDal.GetAll(p => p.BrandId == branId).Count();
            if (result > 20)
            {
                return new ErrorResult(Messages.CarCountOfBrandLimit);
            }

            return new SuccessResult();
        }

    }
}
