using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
            public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);

            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);

            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Color>>  GetAll()
        {
          return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<List<Color>>  GetByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p => p.ColorId ==   id),Messages.SuccessListed);
        }

        public IDataResult<List<Color>> GetById(int entityId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == entityId), Messages.SuccessListed);
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
