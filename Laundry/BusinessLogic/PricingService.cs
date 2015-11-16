using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DTO.Models;

namespace BusinessLogic
{
    public class PricingService
    {
        private LaundryEntities dbContext;

        public PricingService()
        {
            dbContext = new LaundryEntities();
        }

        public IEnumerable<PricesDTO> GetPricesList()
        {
            Mapper.CreateMap<IEnumerable<Prices>, IEnumerable<PricesDTO>>();
            return dbContext.Things.Select(c => new PricesDTO { Id = c.Id }).ToList();
        }
    }
}
