using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CarRentalDbContext db;
        public OrderRepository(CarRentalDbContext context)
        {
            db = context;
        }

        public Order GetOrder(int id)
        {
            return db.Orders.FirstOrDefault(x => x.Id == id);
        }
    }
}
