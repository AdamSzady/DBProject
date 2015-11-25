using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BusinessLogic;

namespace Laundry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult AllowCookies(string ReturnUrl)
        {
            CookieConsent.SetCookieConsent(Response, true);
            return Redirect(ReturnUrl);
        }

        public ActionResult NoCookies(string ReturnUrl)
        {
            CookieConsent.SetCookieConsent(Response, false);
            // if we got an ajax submit, just return 200 OK, else redirect back
            if (Request.IsAjaxRequest())
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            else
                return Redirect(ReturnUrl);
        }
    }
}