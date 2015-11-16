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

        public IEnumerable<Price> GetPricesList()
        {
            return dbContext.Prices.Select(c => new Price
            {
                PriceId = c.Id,
                ServiceName = c.Services.Name,
                ThingName = c.Things.Name,
                Value = (float)c.Price
            }).ToList();
        }

        public void AddThing(ThingsDTO thingDTO, int[] services)
        {
            Mapper.CreateMap<ThingsDTO, Things>();
            Things thing = Mapper.Map<ThingsDTO, Things>(thingDTO);
            dbContext.Things.Add(thing);
            foreach (var price in services)
            {
                dbContext.Prices.Add(new Prices { ThingId = thing.Id, ServiceId = price });
            }
            dbContext.SaveChanges();
        }

        public void Modify(int priceId, float price)
        {
            dbContext.Prices.Find(priceId).Price = price;
            dbContext.SaveChanges();
        }
    }
}
