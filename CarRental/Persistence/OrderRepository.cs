using CarRental.Core;
using CarRental.Core.Models;
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
        public List<Order> GetOrdersWithUniqueStartDate()
        {
            var result = db.Orders.ToList();

            List<string> startDates = new List<string>();

            foreach (var item in result)
            {
                int k = 0;
                for (int i = 0; i < startDates.Count(); i++)
                {
                    if (startDates[i] == item.StartDate.ToString())
                        k++;
                }

                if (k == 0)
                    startDates.Add(item.StartDate.ToString());
            }

            List<Order> orders = new List<Order>();

            foreach (string startDate in startDates)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i].StartDate.ToString() == startDate)
                    {
                        orders.Add(result[i]);
                        result = result.Where(x => x.StartDate.ToString() != startDate).ToList();
                        break;
                    }
                }
            }

            return orders;
        }
        public List<Order> GetOrdersWithUniqueFinalDate()
        {
            var result = db.Orders.ToList();

            List<string> finalDates = new List<string>();

            foreach (var item in result)
            {
                int k = 0;
                for (int i = 0; i < finalDates.Count(); i++)
                {
                    if (finalDates[i] == item.FinalDate.ToString())
                        k++;
                }

                if (k == 0)
                    finalDates.Add(item.FinalDate.ToString());
            }

            List<Order> orders = new List<Order>();

            foreach (string finalDate in finalDates)
            {
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i].FinalDate.ToString() == finalDate)
                    {
                        orders.Add(result[i]);
                        result = result.Where(x => x.FinalDate.ToString() != finalDate).ToList();
                        break;
                    }
                }
            }

            return orders;
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
