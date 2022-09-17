using AutoMapper;
using Microsoft.AspNetCore.Mvc;
 
using RestaurantManagement.Models;
using RestaurantManagement.ModelsViews;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private restaurantdbContext _context;
        private IMapper _mapper;
        public CustomerController(restaurantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var reslut = _context.Customers.ToList();
            var reslutMapped = _mapper.Map<List<CustomerView>>(reslut);
            return Ok(reslutMapped);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dbCustomer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (dbCustomer == null) return BadRequest("Customer is not registered");
            var reslutMapped = _mapper.Map<CustomerView>(dbCustomer);
            return Ok(reslutMapped);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(CustomerView customerView)
        {
            var customer = new Customer()
            {
                FirstName = customerView.FirstName,
                LastName = customerView.LastName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Archived = customerView.Archived,
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerView customerView)
        {
            var dbCustomer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (dbCustomer == null) return BadRequest("Customer is not registered");
            dbCustomer.FirstName = customerView.FirstName;
            dbCustomer.LastName = customerView.LastName;
            dbCustomer.Archived = customerView.Archived;
            dbCustomer.UpdatedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbCustomer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (dbCustomer == null) return BadRequest("Customer is not registered");
            _context.Customers.Remove(dbCustomer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
