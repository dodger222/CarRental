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
        private readonly ICarRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CarController(IUnitOfWork unitOfWork, IMapper mapper, ICarRepository repository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<CarResource> GetCars()
        {
            var cars = repository.GetCars();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("UniqueMake")]
        public IEnumerable<CarResource> GetCarsWithUniqueMake(string unique)
        {
            var cars = repository.GetCarsWithUniqueMake();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("UniqueModel")]
        public IEnumerable<CarResource> GetCarsWithUniqueModel(string unique)
        {
            var cars = repository.GetCarsWithUniqueModel();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = repository.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            var carResource = mapper.Map<Car, CarResource>(car);
            
            return Ok(carResource);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody]CarResource carResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = mapper.Map<CarResource, Car>(carResource);

            repository.Add(car);
            unitOfWork.Complete();

            car = repository.GetCar(car.Id);

            var result = mapper.Map<Car, CarResource>(car);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody]CarResource carResource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = repository.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            mapper.Map(carResource, car);
            repository.Update(car);
            unitOfWork.Complete();

            var result = mapper.Map<Car, CarResource>(car);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = repository.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            repository.Remove(car);
            unitOfWork.Complete();

            return Ok(car);
        }
    }
}
