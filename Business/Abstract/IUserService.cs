using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IBussiniesRepository<User>
    {
        User GetByMail(string email);
        IDataResult<User> GetUserByMail(string email);

        List<OperationClaim> GetClaims(User user);
        IResult AddFindexPoint(int userId);
        IDataResult<User> GetByUserId(int userId);
    }
}
