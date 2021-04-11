using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
           
            _userDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult AddFindexPoint(int userId)
        {
            var result = GetByUserId(userId);

            if (result.Data.FindexPoint < 1900)
            {
                result.Data.FindexPoint += 50;
                Update(result.Data);
            }
            else
            {
                return new ErrorResult(Messages.findexPointMax);
            }


            return new SuccessResult(Messages.findexPointAdd);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<List<User>> GetById(int entityId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == entityId), Messages.SuccessListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.Id == userId));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(user=> user.Email == email));
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
