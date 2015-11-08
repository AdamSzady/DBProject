using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class SingleOrder
    {
        public OrdersDTO Order { get; set; }
        public IEnumerable<OrderPartsDTO> Parts { get; set; }
    }
}
