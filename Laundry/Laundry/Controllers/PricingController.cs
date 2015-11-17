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
        public ActionResult AddThing()
        {
            var services = orderService.GetServicesList();
            var model = new AddThingModel
            {
                Services = services,
                Selected = new List<ServicesDTO>(),
                Posted = new Posted { ServiceIDs = new int[0]},
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddThing(AddThingModel addThing)
        {
            pricingService.AddThing(addThing.Thing, addThing.Posted.ServiceIDs);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddService()
        {
            var things = orderService.GetThingsList();
            var model = new AddServiceModel
            {
                Things = things,
                Selected = new List<ThingsDTO>(),
                Posted = new Posted { ServiceIDs = new int[0] },
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddService(AddServiceModel addService)
        {
            pricingService.AddService(addService.Service, addService.Posted.ServiceIDs);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Modify(int priceId, float price)
        {
            pricingService.Modify(priceId, price);
            return Json(true, JsonRequestBehavior.DenyGet);

        }

        public ActionResult DeletePrice(int id)
        {
            pricingService.DeletePrice(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteThing()
        {
            var model = new DeleteThingModel
            {
                Things = orderService.GetThingsList(),
                Services = orderService.GetServicesList()
            };
            return View("DeleteThing", model);
        }

        public ActionResult Delete(int id, Enums.ThingOrService what)
        {
            switch (what)
            {
                case Enums.ThingOrService.Service:
                    pricingService.DeleteService(id);
                    break;
                case Enums.ThingOrService.Thing:
                    pricingService.DeleteThing(id);
                    break;
            }
            return RedirectToAction("DeleteThing");
        }

    }
}