using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService : IBussiniesRepository<Brand>
    {

        IDataResult<Brand>  GetByBrandId(int id);

    }
}
