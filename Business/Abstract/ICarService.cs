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
        IDataResult<List<CarDetailDto>>  GetAllByBrandId(int id);  

        IDataResult<List<CarDetailDto>> GetAllByColorId(int id);

        IDataResult<List<CarDetailDto>> GetCarDetail(int carId);

        IResult AddTransactinaolTest(Car car);  


    }
}
