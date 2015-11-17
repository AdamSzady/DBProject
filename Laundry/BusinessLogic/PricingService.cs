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

        public void AddService(ServicesDTO serviceDTO, int[] things)
        {
            Mapper.CreateMap<ServicesDTO, Services>();
            Services service = Mapper.Map<ServicesDTO, Services>(serviceDTO);
            dbContext.Services.Add(service);
            foreach (var price in things)
            {
                dbContext.Prices.Add(new Prices { ThingId = price, ServiceId = service.Id });
            }
            dbContext.SaveChanges();
        }

        public void DeletePrice(int id)
        {
            var price = dbContext.Prices.Find(id);
            dbContext.Prices.Remove(price);
            dbContext.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = dbContext.Services.Find(id);
            var prices = dbContext.Prices.Where(p => p.ServiceId == id);
            dbContext.Prices.RemoveRange(prices);
            dbContext.Services.Remove(service);
            dbContext.SaveChanges();
        }

        public void DeleteThing(int id)
        {
            var thing = dbContext.Things.Find(id);
            var prices = dbContext.Prices.Where(p => p.ThingId == id);
            dbContext.Prices.RemoveRange(prices);
            dbContext.Things.Remove(thing);
            dbContext.SaveChanges();
        }
    }
}
