using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Laundry.Models;
using BusinessLogic;
using DTO.Models;

namespace Laundry.Controllers
{
    [Authorize]
    public class MyOrdersController : Controller
    {

        private readonly OrderService orderService;
        private readonly PricingService priceService;

        public MyOrdersController()
        {
            this.orderService = new OrderService();
            this.priceService = new PricingService();
        }

        public MyOrdersController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: MyOrders
        public ActionResult Index()
        {
            MyOrders model = new MyOrders
            {
                Orders = orderService.GetOrdersByClient(User.Identity.GetUserId())         
            };
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddOrder()
        {
            NewOrder model = new NewOrder {
                Order = new OrdersDTO{ }
            };
            //            return PartialView("_NewOrder", model);
            return View("NewOrder", model);
        }

        [HttpPost]
        public ActionResult AddOrder( NewOrder model )
        {
            model.Order.ClientId = User.Identity.GetUserId();
            model.Order.Id = orderService.AddOrder(model.Order);
            model.Prices = priceService.GetPricesList();

            return View("NewOrder", model);          
        }

        [HttpGet]
        public ActionResult AddOrderPart(int orderId, int priceId, int number)
        {
            orderService.AddPart(orderId, priceId, number);

            var model = new NewOrder
            {
                Order = orderService.GetOrderById(orderId),
                OrderParts = orderService.GetOrderParts(orderId).ToList(),
                Prices = priceService.GetPricesList()
            };

            return View("NewOrder", model);
        }

        //[HttpPost]
        //public ActionResult AddOrderPart(NewOrder model)
        //{
        //    //           return PartialView("_NewOrder");
        //    var part = orderService.AddPart(model.Order.Id, model.PriceId, model.Number);
        //    model.OrderParts.Add(part);
        //    return View("NewOrder", model);
        //}
    }
} 