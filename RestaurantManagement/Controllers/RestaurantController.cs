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
    public class RestaurantController : ControllerBase
    {
        private restaurantdbContext _context;
        private IMapper _mapper;
        public RestaurantController(restaurantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get()
        {
            var reslut = _context.Restaurants.ToList();
            var reslutMapped = _mapper.Map<List<RestaurantView>>(reslut);
            return Ok(reslutMapped);
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dbRestaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (dbRestaurant == null) return BadRequest("dbRestaurant is not found");
            var reslutMapped = _mapper.Map<RestaurantView>(dbRestaurant);
            return Ok(reslutMapped);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post(RestaurantView restaurantView)
        {
            var restaurant = new Restaurantt()
            {
                Name = restaurantView.Name,
                PhoneNumber = restaurantView.PhoneNumber,
                Archived = restaurantView.Archived,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, RestaurantView restaurantView)
        {
            var dbRestaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (dbRestaurant == null) return BadRequest("dbRestaurant is not found");
            dbRestaurant.Name = restaurantView.Name;
            dbRestaurant.PhoneNumber = restaurantView.PhoneNumber;
            dbRestaurant.Archived = restaurantView.Archived;
            dbRestaurant.UpdatedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok();

        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbRestaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (dbRestaurant == null) return BadRequest("dbRestaurant is not found");
            _context.Restaurants.Remove(dbRestaurant);
            _context.SaveChanges();
            return Ok();
        }

     
    }
}
