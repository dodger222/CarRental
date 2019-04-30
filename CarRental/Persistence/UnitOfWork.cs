using CarRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalDbContext db;
        private OrderRepository orderRepository;
        private CarRepository carRepository;
        private UserRepository userRepository;

        public UnitOfWork(CarRentalDbContext context)
        {
            db = context;
        }

        public void Complete()
        {
            db.SaveChanges();
        }

        public IOrderRepository OrderRepository => orderRepository ?? new OrderRepository(db);
        public ICarRepository CarRepository => carRepository ?? new CarRepository(db);
        public IUserRepository UserRepository => userRepository ?? new UserRepository(db);
    }
}
