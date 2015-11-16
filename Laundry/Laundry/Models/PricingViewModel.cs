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
        public IEnumerable<PricesDTO> Prices { get; set; }
    }    
}
