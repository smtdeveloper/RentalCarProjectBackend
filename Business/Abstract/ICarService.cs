using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IBussiniesRepository<Car>
    {
        List<Car> GetAllByBrandId(int id);

        List<Car> GetAllByColorId(int id);
    }
}
