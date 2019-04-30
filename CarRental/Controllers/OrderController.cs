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
using System.Linq.Expressions;
using CarRental.Extensions;

namespace CarRental.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<ViewOrderResource> GetOrders(OrderQueryResource queryResource)
        {
            var query = mapper.Map<OrderQueryResource, OrderQuery>(queryResource);
            var viewOrders = unitOfWork.OrderRepository.CreateViewOrderList(query);

            return mapper.Map<List<ViewOrder>, List<ViewOrderResource>>(viewOrders);
        }

        [HttpGet("UniqueStartDate")]
        public List<OrderResource> GetOrdersWithUniqueStartDate(string unique)
        {
            var orders = unitOfWork.OrderRepository.GetOrdersWithUniqueStartDate();

            return mapper.Map<List<Order>, List<OrderResource>>(orders);
        }

        [HttpGet("UniqueFinalDate")]
        public List<OrderResource> GetOrdersWithUniqueFinalDate(string unique)
        {
            var orders = unitOfWork.OrderRepository.GetOrdersWithUniqueFinalDate();

            return mapper.Map<List<Order>, List<OrderResource>>(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = unitOfWork.OrderRepository.GetOrder(id);

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

            unitOfWork.OrderRepository.Add(order);
            unitOfWork.Complete();

            order = unitOfWork.OrderRepository.GetOrder(order.Id);

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

            var order = unitOfWork.OrderRepository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            mapper.Map(orderResource, order);
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.Complete();

            var result = mapper.Map<Order, OrderResource>(order);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = unitOfWork.OrderRepository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            unitOfWork.OrderRepository.Remove(order);
            unitOfWork.Complete();

            return Ok(id);
        }
        
    }
}
