using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        // Loose Coupled -- Gevşek Bağımlılık
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(2000);

            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]  // isimlerle alyans veriyoruz.  // örnek: localhost:44342/api/products/getbyid
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallbybrandid")]  
        public IActionResult GetAllByBrandId(int id)
        {
            var result = _carService.GetAllByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int id)
        {
            var result = _carService.GetAllByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetailDtos()
        {
            Thread.Sleep(2000);
            var result = _carService.GetCarDetailDtos();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}