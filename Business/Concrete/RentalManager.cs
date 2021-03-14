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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<List<Rental>> GetById(int entityId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentalId == entityId), Messages.SuccessListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDto(),Messages.SuccessListed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
