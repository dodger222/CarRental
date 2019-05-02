using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core
{
    public class CarService : ICarService
    {
        private IUnitOfWork Database;
        private IMapper mapper;

        public CarService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            this.mapper = mapper;
        }

        public void SaveCar(CarResource carResource)
        {
            //
            //there must be validation!!!!!!!!!!
            //

            var car = new Car
            {
                Make = carResource.Make,
                Model = carResource.Model,
                CarClass = carResource.CarClass,
                YearOfIssue = carResource.YearOfIssue,
                RegistrationNumber = carResource.RegistrationNumber
            };

            Database.CarRepository.Add(car);
            Database.Complete();
        }

        public CarResource GetCar(int? id)
        {
            if (!id.HasValue)
                throw new ValidationException("The Car's id value is not set", String.Empty);

            var car = Database.CarRepository.GetCar(id.Value);

            if (car == null)
                throw new ValidationException($"The Car with id = {id} was not found", String.Empty);

            return mapper.Map<Car, CarResource>(car);
        }

        public void UpdateCar(CarResource carResource)
        {
            //
            //there must be validation!!!!!!!!!!
            //

            var car = Database.CarRepository.GetCar(carResource.Id);

            if(car != null)
            {
                mapper.Map(carResource, car);
                Database.CarRepository.Update(car);
                Database.Complete();
            }
        }

        public void DeleteCar(int? id)
        {
            if (!id.HasValue)
                throw new ValidationException("The Car's id value is not set", String.Empty);

            var car = Database.CarRepository.GetCar(id.Value);

            if (car == null)
                throw new ValidationException($"The Car with id = {id} was not found", String.Empty);

            Database.CarRepository.Remove(car);
            Database.Complete();
        }

        public List<CarResource> GetCars()
        {
            var cars = Database.CarRepository.GetCars();

            return mapper.Map<List<Car>, List<CarResource>>(cars);
        }

        public List<CarResource> GetCarsWithUniqueMake()
        {
            return mapper.Map<List<Car>, List<CarResource>>(Database.CarRepository.GetCarsWithUniqueMake());
        }

        public List<CarResource> GetCarsWithUniqueModel()
        {
            return mapper.Map<List<Car>, List<CarResource>>(Database.CarRepository.GetCarsWithUniqueModel());
        }
    }
}
