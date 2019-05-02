using CarRental.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core
{
    public interface ICarService
    {
        void SaveCar(CarResource carResource);
        CarResource GetCar(int? id);
        void UpdateCar(CarResource carResource);
        void DeleteCar(int? id);
        List<CarResource> GetCars();
        List<CarResource> GetCarsWithUniqueMake();
        List<CarResource> GetCarsWithUniqueModel();
    }
}
