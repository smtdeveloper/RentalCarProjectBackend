using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IBussiniesRepository<Car>
    {
        IDataResult<List<Car>>  GetAllByBrandId(int id);  

        IDataResult<List<Car>> GetAllByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarDetailDtos();



    }
}
