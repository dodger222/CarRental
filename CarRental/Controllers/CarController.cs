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

        public CarController(CarRentalDbContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<CarResource> GetCars()
        {
            var cars = db.Cars.ToList();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == id);
            return car;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return Ok(car);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Car car)
        {
            if (ModelState.IsValid)
            {
                db.Update(car);
                db.SaveChanges();
                return Ok(car);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
            return Ok(car);
        }
    }
}
