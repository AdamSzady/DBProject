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
    public class OrderService
    {
        private LaundryEntities dbContext;

        public OrderService()
        {
            dbContext = new LaundryEntities();
        }

        public int AddOrder(OrdersDTO order)
        {
            order.WorkerId = "123";
            Mapper.CreateMap<OrdersDTO, Orders>();
            Orders newOrder = Mapper.Map<OrdersDTO, Orders>(order);
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
            return newOrder.Id;
        }

        public OrderPartsDTO AddPart(int orderId, int priceId, int number)
        {
            Mapper.CreateMap<OrderParts, OrderPartsDTO>();

            var part = new OrderParts
            {
                OrderId = orderId,
                PriceId = priceId,
                Number = number,
            };
            dbContext.OrderParts.Add(part);
            dbContext.SaveChanges();
            return Mapper.Map<OrderParts, OrderPartsDTO>(part);
        }

        public IEnumerable<SingleOrder> GetOrdersByClient(string userId)
        {
            Mapper.CreateMap<Orders, OrdersDTO>();

            var orders = dbContext.Orders.Where(o => o.ClientId == userId).ToList();
            List<SingleOrder> list = new List<SingleOrder>();
            foreach (var order in orders)
            {
                var parts = dbContext.OrderParts
                                    .Where(o => o.OrderId == order.Id)
                                    .Select(c => new OrderPartsDTO {
                                        Number = c.Number ?? 0,
                                        OrderId = c.OrderId,
                                        PriceId = c.PriceId ?? 0,
                                        Service = c.Prices.Services.Name,
                                        Thing = c.Prices.Things.Name,
                                    })
                                    .ToList();

                //                var p = Mapper.Map<IEnumerable<OrderParts>, IEnumerable<OrderPartsDTO>>(parts);
                list.Add(new SingleOrder
                {
                    Order = Mapper.Map<Orders, OrdersDTO>(order),
                    Parts = parts
                });
            }
            return list;
        }

        public OrdersDTO GetOrderById(int id)
        {
            Mapper.CreateMap<Orders, OrdersDTO>();
            var order = dbContext.Orders.Find(id);
            return Mapper.Map<Orders, OrdersDTO>(order);
        }

        public IEnumerable<OrderPartsDTO> GetOrderParts(int id)
        {
            var parts = dbContext.OrderParts
                .Where(p => p.OrderId == id)
                .Select(p => new OrderPartsDTO { Service = p.Prices.Services.Name, Thing = p.Prices.Things.Name, Number = p.Number ?? 0 }).ToList();
            return parts;
        }

        public IEnumerable<ThingsDTO> GetThingsList()
        {
            Mapper.CreateMap<IEnumerable<Things>, IEnumerable<ThingsDTO>>();
            return dbContext.Things.Select(c => new ThingsDTO { Id = c.Id, Name = c.Name }).ToList();
        }

        public IEnumerable<ServicesDTO> GetServicesList()
        {
            Mapper.CreateMap<IEnumerable<Services>, IEnumerable<ServicesDTO>>();
            return dbContext.Services.Select(c => new ServicesDTO { Id = c.Id, Name = c.Name }).ToList();
        }
    }
}
