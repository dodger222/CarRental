using AutoMapper;
using CarRental.Controllers.Resources;
using CarRental.Core.Models;
using CarRental.Core;
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
        private readonly CarRentalDbContext db;
        private readonly IMapper mapper;
        private readonly IOrderRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(CarRentalDbContext db, IUnitOfWork unitOfWork, IMapper mapper, IOrderRepository repository)
        {
            this.db = db;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public List<ViewOrderResource> GetOrders(Filter filter)
        {
            var viewOrders = CreateViewOrderList(filter);

            return mapper.Map<List<ViewOrder>, List<ViewOrderResource>>(viewOrders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = repository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderResource = mapper.Map<Order, OrderResource>(order);

            return Ok(orderResource);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody]OrderResource orderResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = mapper.Map<OrderResource, Order>(orderResource);

            repository.Add(order);
            unitOfWork.Complete();

            order = repository.GetOrder(order.Id);

            var result = mapper.Map<Order, OrderResource>(order);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody]OrderResource orderResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = repository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            mapper.Map(orderResource, order);
            repository.Update(order);
            unitOfWork.Complete();

            var result = mapper.Map<Order, OrderResource>(order);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = repository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            repository.Remove(order);
            unitOfWork.Complete();

            return Ok(id);
        }


        // получение списка Номеров ВУ пользователей
        //private List<SelectListItem> GetUsers()
        //{
        //    var users = db.Users.ToList();
        //    List<SelectListItem> selectItems = new List<SelectListItem>();

        //    foreach (var item in users)
        //    {
        //        selectItems.Add(new SelectListItem { Text = item.DriveLicenseNumber, Value = item.Id.ToString() });
        //    }

        //    return selectItems;
        //}

        // получение списка Регистрационных номеров автомобилей
        //private List<SelectListItem> GetAutos()
        //{
        //    var cars = db.Cars.ToList();
        //    List<SelectListItem> selectItems = new List<SelectListItem>();

        //    foreach (var item in cars)
        //    {
        //        selectItems.Add(new SelectListItem { Text = item.RegistrationNumber, Value = item.Id.ToString() });
        //    }

        //    return selectItems;
        //}

        
        private List<ViewOrder> CreateViewOrderList(Filter filter)
        {
            var result = from o in db.Orders
                         join u in db.Users on o.UserId equals u.Id
                         join c in db.Cars on o.CarId equals c.Id
                         select new
                         {
                             Id = o.Id,
                             UserId = u.Id,
                             UserLastName = u.LastName,
                             UserFirstName = u.FirstName,
                             CarId = c.Id,
                             CarMake = c.Make,
                             CarModel = c.Model,
                             CarRegistrationNumber = c.RegistrationNumber,
                             StartDate = o.StartDate,
                             FinalDate = o.FinalDate
                         };

            if (filter.UserId.HasValue)
            {
                result = result.Where(v => v.UserId == filter.UserId.Value);
            }
            if (filter.CarId.HasValue)
            {
                result = result.Where(v => v.CarId == filter.CarId.Value);
            }

            List<ViewOrder> viewOrders = new List<ViewOrder>();

            foreach (var item in result)
            {
                ViewOrder viewOrder = new ViewOrder
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    UserLastName = item.UserLastName,
                    UserFirstName = item.UserFirstName,
                    CarId = item.Id,
                    CarMake = item.CarMake,
                    CarModel = item.CarModel,
                    CarRegistrationNumber = item.CarRegistrationNumber,
                    StartDate = item.StartDate,
                    FinalDate = item.FinalDate
                };

                viewOrders.Add(viewOrder);
            }

            return viewOrders;
        }
    }
}
