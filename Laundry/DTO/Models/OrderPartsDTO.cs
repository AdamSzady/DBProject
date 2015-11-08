using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class OrderPartsDTO
    {
        public int OrderId { get; set; }
        public int PriceId { get; set; }
        public int Number { get; set; }
        public string Thing { get; set; }
        public string Service { get; set; }
    }
}
