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
    public class PricingController : Controller
    {

        private readonly PricingService pricingService;

        public PricingController()
        {
            this.pricingService = new PricingService();
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
    }
}