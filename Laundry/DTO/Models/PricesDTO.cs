using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class PricesDTO
    {
        public int Id { get; set; }
        public int ThingId { get; set; }
        public int ServiceId { get; set; }
        public float Price { get; set; }
    }
}
