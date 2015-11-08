﻿using System;
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

        public void AddOrder(OrdersDTO order)
        {
            order.WorkerId = "123";
            Mapper.CreateMap<OrdersDTO, Orders>();
            dbContext.Orders.Add(Mapper.Map<OrdersDTO, Orders>(order));
            dbContext.SaveChanges();
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
