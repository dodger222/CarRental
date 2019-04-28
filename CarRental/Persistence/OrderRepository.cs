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

        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrder(int id)
        {
            return db.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            db.Remove(order);
        }

        public void Update(Order order)
        {
            db.Update(order);
        }
    }
}
