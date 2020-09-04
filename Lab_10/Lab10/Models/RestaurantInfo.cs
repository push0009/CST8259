using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10.Models
{
    public class RestaurantInfo
    {
        public string Name { get; set; }
        public Address Location { get; set; }
        public string Summary { get; set; }
        public int Rating { get; set; }
    }
}
