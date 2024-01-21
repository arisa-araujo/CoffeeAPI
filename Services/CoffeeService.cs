using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeAPI.Models;

namespace CoffeeAPI.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly List<Coffee> _coffees;

        public CoffeeService()
        {
            _coffees = new List<Coffee>
            {
                new Coffee {Name = "Black Coffee", Code = "blk", CaffeineLevel = 95},
                new Coffee {Name = "Espresso", Code = "esp", CaffeineLevel = 63},
                new Coffee {Name = "Cappuccino", Code = "cap", CaffeineLevel = 63},
                new Coffee {Name = "Latte", Code = "lat", CaffeineLevel = 63},
                new Coffee {Name = "Flat White", Code = "wht", CaffeineLevel = 63},
                new Coffee {Name = "Cold Brew", Code = "cld", CaffeineLevel = 120},
                new Coffee {Name = "Decaf Coffee", Code = "dec", CaffeineLevel = 7}
            };
        }

        public List<Coffee> GetCoffees()
        {
            return _coffees;
        }

        public List<CoffeeRecommendation> GetRecommendations(List<CoffeeConsumption> recentConsumptions)
        {
            var totalCaffeine = CalculateTotalCaffeineLevel(recentConsumptions);

            var recommendations = new List<CoffeeRecommendation>();
            
            foreach (var coffee in _coffees)
            {
                recommendations.Add(new CoffeeRecommendation
                {
                    Name = coffee.Name,
                    Code = coffee.Code,
                    Wait = CalculateWaitTime(coffee.CaffeineLevel, totalCaffeine)
                });
            }

            return recommendations;
        }

        private double CalculateTotalCaffeineLevel(List<CoffeeConsumption> coffeeConsumptions)
        {
            return coffeeConsumptions.Sum(coffee =>
            {
                var caffeineLevel = _coffees
                    .Where(c => c.Code == coffee.Code)
                    .Select(c => c.CaffeineLevel)
                    .FirstOrDefault();

                return caffeineLevel * Math.Pow(0.5, coffee.Time / 300.0);
            });
        }

        private int CalculateWaitTime(double coffeeCaffeineLevel, double totalCaffeine)
        {
            return (int)Math.Max(0, Math.Ceiling(300 * Math.Log((175 - coffeeCaffeineLevel) / totalCaffeine, 0.5)));
        }
    }
}