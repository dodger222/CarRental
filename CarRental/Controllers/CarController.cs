using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Core.Models;
using CarRental.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Route("api/cars")]
    public class CarController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICarService carService;

        public CarController(IUnitOfWork unitOfWork, IMapper mapper, ICarService carService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.carService = carService;
        }

        [HttpGet]
        public IEnumerable<CarResource> GetCars()
        {
            var cars = carService.GetCars();

            return carService.GetCars();
        }

        [HttpGet("UniqueMake")]
        public IEnumerable<CarResource> GetCarsWithUniqueMake(string unique)
        {
            var cars = carService.GetCarsWithUniqueMake();

            return cars;
        }

        [HttpGet("UniqueModel")]
        public IEnumerable<CarResource> GetCarsWithUniqueModel(string unique)
        {
            var cars = carService.GetCarsWithUniqueModel();

            return cars;
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = carService.GetCar(id);
            
            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody]CarResource carResource)
        {
            carService.SaveCar(carResource);

            return Ok(carResource);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody]CarResource carResource)
        {
            carService.UpdateCar(carResource);

            return Ok(carResource);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = carService.GetCar(id);

            carService.DeleteCar(id);

            return Ok(car);
        }
    }
}
