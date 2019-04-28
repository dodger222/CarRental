using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext db;
        public CarRepository(CarRentalDbContext context)
        {
            db = context;
        }

        public List<Car> GetCars()
        {
            return db.Cars.ToList();
        }

        public Car GetCar(int id)
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Car car)
        {
            db.Cars.Add(car);
        }

        public void Remove(Car car)
        {
            db.Remove(car);
        }

        public void Update(Car car)
        {
            db.Update(car);
        }
    }
}
