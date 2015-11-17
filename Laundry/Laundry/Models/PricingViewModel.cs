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

    public class AddThingModel
    {
        public ThingsDTO Thing { get; set; }
        public List<PricesDTO> Prices { get; set; }
        public IEnumerable<ServicesDTO> Services { get; set; }
        public IEnumerable<ServicesDTO> Selected { get; set; }
        public Posted Posted { get; set; }
    }

    public class AddServiceModel
    {
        public ServicesDTO Service { get; set; }
        public List<PricesDTO> Prices { get; set; }
        public IEnumerable<ThingsDTO> Things { get; set; }
        public IEnumerable<ThingsDTO> Selected { get; set; }
        public Posted Posted { get; set; }
    }

    public class Posted
    {
        public int[] ServiceIDs { get; set; }
    }

    public class DeleteThingModel
    {
        public IEnumerable<ThingsDTO> Things { get; set; }
        public IEnumerable<ServicesDTO> Services { get; set; }

    }
}
