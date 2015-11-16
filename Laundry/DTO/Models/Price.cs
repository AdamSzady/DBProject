using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Price
    {
        public int PriceId { get; set; }
        public string ThingName { get; set; }
        public string ServiceName { get; set; }
        public float? Value { get; set; }
    }
}
