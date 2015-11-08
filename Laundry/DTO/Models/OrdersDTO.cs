using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string WorkerId { get; set; }
        public string GivingAddress { get; set; }
        public DateTime GivingDate { get; set; }
        public string ReceiveAddress { get; set; }
        public DateTime ReceiveDate { get; set; }
        public double Price { get; set; }
    }
}
