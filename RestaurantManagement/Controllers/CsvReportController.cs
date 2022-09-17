using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Extentions;
using RestaurantManagement.Models;
using RestaurantManagement.ModelsViews;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvReportController : ControllerBase
    {
        private restaurantdbContext _context;
        private IMapper _mapper;
        public CsvReportController(restaurantdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<CsvReportController>






        [HttpGet]
        public IActionResult Get()
        {
            var dbreport = _context.CsvViews.ToList();
            foreach (var Extentioin in dbreport)
            {
                Extentioin.RestaurantName.CapitalizeName();
                Extentioin.MostPurchasedCustomer.CapitalizeName();
            }
            var pathcsv = Path.Combine(Environment.CurrentDirectory, $"Report.csv");
            var reslutMapped = _mapper.Map<List<CsvView>>(dbreport);
            using (var streamWriter = new StreamWriter(pathcsv))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(reslutMapped);
            }

            return Ok();
        }


    }
}
