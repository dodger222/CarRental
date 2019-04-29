using CarRental.Core;
using CarRental.Core.Models;
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

        public List<Car> GetCarsWithUniqueMake()
        {
            var result = db.Cars.ToList();

            List<string> makes = new List<string>();

            foreach (var item in result)
            {
                int k = 0;
                for (int i = 0; i < makes.Count(); i++)
                {
                    if (makes[i] == item.Make)
                        k++;
                }

                if (k == 0)
                    makes.Add(item.Make);
            }

            List<Car> cars = new List<Car>();

            foreach (string make in makes)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i].Make == make)
                    {
                        cars.Add(result[i]);
                        result = result.Where(x => x.Make != make).ToList();
                        break;
                    }
                }
            }

            return cars;
        }

        public List<Car> GetCarsWithUniqueModel()
        {
            var result = db.Cars.ToList();

            List<string> models = new List<string>();

            foreach (var item in result)
            {
                int k = 0;
                for (int i = 0; i < models.Count(); i++)
                {
                    if (models[i] == item.Model)
                        k++;
                }

                if (k == 0)
                    models.Add(item.Make);
            }

            List<Car> cars = new List<Car>();

            foreach (string model in models)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i].Model == model)
                    {
                        cars.Add(result[i]);
                        result = result.Where(x => x.Model != model).ToList();
                        break;
                    }
                }
            }

            return cars;
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
