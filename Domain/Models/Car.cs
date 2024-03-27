using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Car
    {
        public string CarName { get; set; }
        public string Model { get; set; }
        public double EngineCapacity { get; set; }
        public int HorsePower { get; set; }

        public int PublishedYear { get; set; }
    }
}
