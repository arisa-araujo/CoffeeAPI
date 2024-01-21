using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAPI.Models;
using CoffeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeService _coffeeService;

        public CoffeeController(CoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("coffees")]
        public ActionResult<List<Coffee>> GetCoffees()
        {
            return Ok(_coffeeService.GetCoffees());
        }

        [HttpPost("calculate")]
        public ActionResult<List<CoffeeRecommendation>> CalculateRecommendations([FromBody] List<CoffeeConsumption> coffeeConsumptions)
        {
            var recommendations = _coffeeService.GetRecommendations(coffeeConsumptions);
            return Ok(recommendations);
        }
    }

}