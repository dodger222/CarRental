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

        public CarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<CarResource> GetCars()
        {
            var cars = unitOfWork.CarRepository.GetCars();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("UniqueMake")]
        public IEnumerable<CarResource> GetCarsWithUniqueMake(string unique)
        {
            var cars = unitOfWork.CarRepository.GetCarsWithUniqueMake();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("UniqueModel")]
        public IEnumerable<CarResource> GetCarsWithUniqueModel(string unique)
        {
            var cars = unitOfWork.CarRepository.GetCarsWithUniqueModel();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = unitOfWork.CarRepository.GetCar(id);

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

            unitOfWork.CarRepository.Add(car);
            unitOfWork.Complete();

            car = unitOfWork.CarRepository.GetCar(car.Id);

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

            var car = unitOfWork.CarRepository.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            mapper.Map(carResource, car);
            unitOfWork.CarRepository.Update(car);
            unitOfWork.Complete();

            var result = mapper.Map<Car, CarResource>(car);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = unitOfWork.CarRepository.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            unitOfWork.CarRepository.Remove(car);
            unitOfWork.Complete();

            return Ok(car);
        }
    }
}
