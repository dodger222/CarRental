using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Models;
using CarRental.Persistence;
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
        CarRentalDbContext db;
        private readonly IMapper mapper;
        private readonly ICarRepository repository;

        public CarController(CarRentalDbContext context, IMapper mapper, ICarRepository repository)
        {
            db = context;
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<CarResource> GetCars()
        {
            var cars = db.Cars.ToList();

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

            db.Cars.Add(car);
            db.SaveChanges();

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
            db.Update(car);
            db.SaveChanges();

            var result = mapper.Map<Car, CarResource>(car);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = db.Cars.FirstOrDefault(x => x.Id == id);

            if(car == null)
            {
                return NotFound();
            }

            db.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }
    }
}
