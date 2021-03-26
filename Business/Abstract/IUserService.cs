using Core.Concrete;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IBussiniesRepository<User>
    {
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
