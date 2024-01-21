using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAPI.Models;

namespace CoffeeAPI.Services
{
    public interface ICoffeeService
    {
        List<Coffee> GetCoffees();
        List<CoffeeRecommendation> GetRecommendations(List<CoffeeConsumption> recentConsumptions);
    }
}