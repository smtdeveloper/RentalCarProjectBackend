using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService : IBussiniesRepository<Color>
    {
        IDataResult<List<Color>>  GetByColorId(int id);
    }
}
