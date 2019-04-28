using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        void Add(Car car);
        void Remove(Car car);
        void Update(Car car);
        List<Car> GetCars();
    }
}
