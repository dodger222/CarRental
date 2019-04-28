using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        void Add(Order order);
        void Remove(Order order);
        void Update(Order order);
        List<Order> GetOrders();
    }
}
