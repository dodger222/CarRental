using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Models;
using CarRental.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        CarRentalDbContext db;
        private readonly IMapper mapper;

        public OrderController(CarRentalDbContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<ViewOrderResource> GetOrders(Filter filter)
        {
            var viewOrders = CreateViewOrderList(filter);

            return mapper.Map<List<ViewOrder>, List<ViewOrderResource>>(viewOrders);
        }

        //[HttpGet]
        //public List<ViewOrder> GetFilteredOrdersByName()
        //{

        //}

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            if(ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return Ok(order);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            if(ModelState.IsValid)
            {
                db.Update(order);
                db.SaveChanges();
                return Ok(order);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);

            if(order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }

            return Ok(order);
        }


        // получение списка Номеров ВУ пользователей
        private List<SelectListItem> GetUsers()
        {
            var users = db.Users.ToList();
            List<SelectListItem> selectItems = new List<SelectListItem>();

            foreach (var item in users)
            {
                selectItems.Add(new SelectListItem { Text = item.DriveLicenseNumber, Value = item.Id.ToString() });
            }

            return selectItems;
        }

        // получение списка Регистрационных номеров автомобилей
        private List<SelectListItem> GetAutos()
        {
            var cars = db.Cars.ToList();
            List<SelectListItem> selectItems = new List<SelectListItem>();

            foreach (var item in cars)
            {
                selectItems.Add(new SelectListItem { Text = item.RegistrationNumber, Value = item.Id.ToString() });
            }

            return selectItems;
        }

        private List<ViewOrder> CreateViewOrderList(Filter filter)
        {
            var result = from o in db.Orders
                         join u in db.Users on o.UserId equals u.Id
                         join a in db.Cars on o.CarId equals a.Id
                         select new
                         {
                             Id = o.Id,
                             UserId = u.Id,
                             UserFirstName = u.FirstName,
                             CarId = a.Id,
                             CarMake = a.Make,
                             StartDate = o.StartDate,
                             FinalDate = o.FinalDate
                         };

            if (filter.UserId.HasValue)
            {
                result = result.Where(v => v.UserId == filter.UserId.Value);
            }

            List<ViewOrder> viewOrders = new List<ViewOrder>();

            foreach (var item in result)
            {
                ViewOrder viewOrder = new ViewOrder
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    UserFirstName = item.UserFirstName,
                    CarId = item.Id,
                    CarMake = item.CarMake,
                    StartDate = item.StartDate,
                    FinalDate = item.FinalDate
                };

                viewOrders.Add(viewOrder);
            }

            return viewOrders;
        }
    }
}
