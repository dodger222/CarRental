using CarRental.Core;
using CarRental.Core.Models;
using CarRental.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<ViewOrder> CreateViewOrderList(OrderQuery queryObj)
        {
            var result = from o in db.Orders
                         join u in db.Users on o.UserId equals u.Id
                         join c in db.Cars on o.CarId equals c.Id
                         select new
                         {
                             Id = o.Id,
                             UserId = o.UserId,
                             UserLastName = u.LastName,
                             UserFirstName = u.FirstName,
                             CarId = o.CarId,
                             CarMake = c.Make,
                             CarModel = c.Model,
                             CarRegistrationNumber = c.RegistrationNumber,
                             StartDate = o.StartDate,
                             FinalDate = o.FinalDate
                         };

            List<ViewOrder> viewOrders = new List<ViewOrder>();

            foreach (var item in result)
            {
                ViewOrder viewOrder = new ViewOrder
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    UserLastName = item.UserLastName,
                    UserFirstName = item.UserFirstName,
                    CarId = item.CarId,
                    CarMake = item.CarMake,
                    CarModel = item.CarModel,
                    CarRegistrationNumber = item.CarRegistrationNumber,
                    StartDate = item.StartDate,
                    FinalDate = item.FinalDate
                };

                viewOrders.Add(viewOrder);
            }

            if (queryObj.UserFirstName != null)
            {
                viewOrders = viewOrders.Where(v => v.UserFirstName == queryObj.UserFirstName).ToList();
            }
            if (queryObj.CarMake != null)
            {
                viewOrders = viewOrders.Where(v => v.CarMake == queryObj.CarMake).ToList();
            }
            if (queryObj.CarModel != null)
            {
                viewOrders = viewOrders.Where(v => v.CarModel == queryObj.CarModel).ToList();
            }
            if (queryObj.StartDate != null)
            {
                viewOrders = viewOrders.Where(v => v.StartDate.ToString() == queryObj.StartDate).ToList();
            }
            if (queryObj.FinalDate != null)
            {
                viewOrders = viewOrders.Where(v => v.FinalDate.ToString() == queryObj.FinalDate).ToList();
            }

            var columnsMap = new Dictionary<string, Expression<Func<ViewOrder, object>>>()
            {
                ["userFirstName"] = v => v.UserFirstName,
                ["userLastName"] = v => v.UserLastName,
                ["carMake"] = v => v.CarMake,
                ["carModel"] = v => v.CarModel,
                ["carRegistrationNumber"] = v => v.CarRegistrationNumber,
                ["startDate"] = v => v.StartDate,
                ["finalDate"] = v => v.FinalDate,
            };

            viewOrders = viewOrders.ApplyOrdering(queryObj, columnsMap);

            return viewOrders;
        }
    }
}
