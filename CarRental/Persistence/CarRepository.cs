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

        public Car GetCar(int id)
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}
