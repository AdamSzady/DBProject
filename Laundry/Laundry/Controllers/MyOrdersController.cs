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

        public MyOrdersController()
        {
            this.orderService = new OrderService();
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
            return PartialView("_NewOrder", model);
        }

        [HttpPost]
        public ActionResult AddOrder( NewOrder model )
        {
            model.Order.ClientId = User.Identity.GetUserId();
            model.Order.Id = orderService.AddOrder(model.Order);
            model.Things = orderService.GetThingsList();
            model.Services = orderService.GetServicesList();
            var model2 = new MyOrders
            {
                Orders = orderService.GetOrdersByClient(User.Identity.GetUserId()),
                NewOrder = model,
            };
            return View("Index", model2);          
        }

        [HttpPost]
        public ActionResult AddOrderPart(int orderId, int number, int thingId, int serviceId)
        {
            //           return PartialView("_NewOrder");
            orderService.AddPart(orderId, thingId, serviceId, number);
            return Json(true, JsonRequestBehavior.DenyGet);

        }
    }
}