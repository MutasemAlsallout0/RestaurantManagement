using AutoMapper;
using Microsoft.AspNetCore.Mvc;
 
using RestaurantManagement.Models;
using RestaurantManagement.ModelsViews;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private restaurantdbContext _context;
        public OrderController(restaurantdbContext context)
        {
            _context = context;
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post(OrderView orderView)
        {
            var checkAvilabllty = isAvailable(orderView.RestaurantMenuId);
            if (!checkAvilabllty) return BadRequest("Not available now");

            var order = new RestaurantMenuCustomer()
            {
                RestaurantMenuId = orderView.RestaurantMenuId,
                CustomerId = orderView.CustomerId,
            };
            _context.RestaurantMenuCustomers.Add(order);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderView orderView)
        {
            var dbOrder = _context.RestaurantMenuCustomers.FirstOrDefault(x => x.Id == id);
            if (dbOrder == null) return BadRequest("Order not found");

            var checkAvilabllty = isAvailable(orderView.RestaurantMenuId);
            if (!checkAvilabllty) return BadRequest("Not available now");

            dbOrder.CustomerId = orderView.CustomerId;
            dbOrder.RestaurantMenuId = orderView.RestaurantMenuId;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbOrder = _context.RestaurantMenuCustomers.FirstOrDefault(x => x.Id == id);
            if (dbOrder == null) return BadRequest("Order not found");
            _context.RestaurantMenuCustomers.Remove(dbOrder);
            _context.SaveChanges();
            return Ok();
        }

        private bool isAvailable(int id)
        {
            var checkQuantity = _context.RestaurantMenus.FirstOrDefault(x => x.Id == id);


            if (checkQuantity.Quantity > 0) return true;
            return false;
        }
    }
}
