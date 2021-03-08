using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class BrandManager  : IBrandService
    {
        IBrandDal _brandDal;
        private EfColorDal efColorDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public BrandManager(EfColorDal efColorDal)
        {
            this.efColorDal = efColorDal;
        }

        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Brand>>  GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand>  GetByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == id));
        }

        public IDataResult<List<Brand>>  GetById(int entityId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == entityId));
        }

        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
