using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
 

namespace CoffeeAPI.Models
{
    public class Coffee
    {
        public string Code { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int CaffeineLevel { get; set; }
    }
}