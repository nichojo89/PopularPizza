using Newtonsoft.Json;
using System.Collections.Generic;

namespace PopularPizza.Models
{
    public class Pizza
    {
        [JsonProperty(PropertyName = "toppings")]
        public IList<string> Toppings { get; set; }
    }
}
