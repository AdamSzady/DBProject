using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace Laundry.Models
{
    public class Pricing
    {
        public IEnumerable<Price> Prices { get; set; }
    }

    public class AddThing
    {
        public ThingsDTO Thing { get; set; }
        public List<PricesDTO> Prices { get; set; }
        public IEnumerable<ServicesDTO> Services { get; set; }
        public IEnumerable<ServicesDTO> Selected { get; set; }
        public PostedServices Posted { get; set; }
    }

    public class PostedServices
    {
        public int[] ServiceIDs { get; set; }
    }
}
