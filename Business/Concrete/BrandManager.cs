using Business.Abstract;
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

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int id)
        {
            return _brandDal.Get(c => c.BrandId == id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
