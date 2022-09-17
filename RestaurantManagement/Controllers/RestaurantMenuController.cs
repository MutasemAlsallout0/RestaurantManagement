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
    public class RestaurantMenuController : ControllerBase
    {
        private restaurantdbContext _context;
        private IMapper _mapper;
        public RestaurantMenuController(restaurantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<RestaurantMenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var reslut = _context.RestaurantMenus.ToList();
            var reslutMapped = _mapper.Map<List<RestaurantMenuView>>(reslut);
            return Ok(reslutMapped);
        }

        // GET api/<RestaurantMenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dbRestaurantMenus = _context.RestaurantMenus.FirstOrDefault(x => x.Id == id);
            if (dbRestaurantMenus == null) return BadRequest("RestaurantMenus is not found");
            var reslutMapped = _mapper.Map<RestaurantMenuView>(dbRestaurantMenus);
            return Ok(reslutMapped);
        }

        // POST api/<RestaurantMenuController>
        [HttpPost]
        public IActionResult Post(RestaurantMenuView restaurantMenuView)
        {
            var restaurantMenu = new RestaurantMenu()
            {
                MealName = restaurantMenuView.MealName,
                PriceInNis = restaurantMenuView.PriceInNis,
                Quantity = restaurantMenuView.Quantity,
                Archived = restaurantMenuView.Archived,
                PriceInUsd = restaurantMenuView.PriceInNis / 3.5,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                RestaurantId = restaurantMenuView.RestaurantId,
            };
            _context.RestaurantMenus.Add(restaurantMenu);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<RestaurantMenuController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, RestaurantMenuView restaurantMenuView)
        {
            var dbRestaurantMenus = _context.RestaurantMenus.FirstOrDefault(x => x.Id == id);
            if (dbRestaurantMenus == null) return BadRequest("RestaurantMenus is not found");
            dbRestaurantMenus.MealName = restaurantMenuView.MealName;
            dbRestaurantMenus.PriceInNis = dbRestaurantMenus.PriceInNis;
            dbRestaurantMenus.Quantity = restaurantMenuView.Quantity;
            dbRestaurantMenus.Archived = dbRestaurantMenus.Archived;
            dbRestaurantMenus.UpdatedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<RestaurantMenuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbRestaurantMenus = _context.RestaurantMenus.FirstOrDefault(x => x.Id == id);
            if (dbRestaurantMenus == null) return BadRequest("RestaurantMenus is not found");
            _context.RestaurantMenus.Remove(dbRestaurantMenus);
            _context.SaveChanges();
            return Ok();
        }

   
    }
}
