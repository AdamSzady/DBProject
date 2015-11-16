using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Laundry.Models;
using BusinessLogic;
using DTO.Models;
//using DTO.Models;

namespace Laundry.Controllers
{
    public class PricingController : Controller
    {

        private readonly PricingService pricingService;
        private readonly OrderService orderService;

        public PricingController()
        {
            this.pricingService = new PricingService();
            this.orderService = new OrderService();
        }

        public PricingController(PricingService pricingService)
        {
            this.pricingService = pricingService;
        }

        // GET: Prices
        public ActionResult Index()
        {
            Pricing model = new Pricing
            {
                Prices = pricingService.GetPricesList()         
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddPosition()
        {
            var services = orderService.GetServicesList();
            var model = new AddThing
            {
                Services = services,
                Selected = new List<ServicesDTO>(),
                Posted = new PostedServices { ServiceIDs = new int[0]},
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPosition(AddThing addThing)
        {
            pricingService.AddThing(addThing.Thing, addThing.Posted.ServiceIDs);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Modify(int priceId, float price)
        {
            pricingService.Modify(priceId, price);
            return Json(true, JsonRequestBehavior.DenyGet);

        }
    }
}