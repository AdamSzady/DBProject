using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace Laundry.Models
{
    public class MyOrders
    {
        public IEnumerable<SingleOrder> Orders { get; set; }
        public NewOrder NewOrder { get; set; }
    }

    public class NewOrder
    {
        public OrdersDTO Order { get; set; }
        public IEnumerable<OrderPartsDTO> OrderParts { get; set; }
        public IEnumerable<ThingsDTO> Things { get; set; }
        public IEnumerable<ServicesDTO> Services { get; set; }
        public IEnumerable<Price> Prices { get; set; }
    }
}
