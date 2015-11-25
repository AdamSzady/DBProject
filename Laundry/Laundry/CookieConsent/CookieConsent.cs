﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laundry
{
    public static class CookieConsent
    {
        public const string CONSENT_COOKIE_NAME = "CookieConsent";
        public static void SetCookieConsent(HttpResponseBase response, bool consent)
        {
            var consentCookie = new HttpCookie(CONSENT_COOKIE_NAME);
            consentCookie.Value = consent ? "true" : "false";
            consentCookie.Expires = DateTime.UtcNow.AddYears(1);
            response.Cookies.Set(consentCookie);
        }

        public static bool AskCookieConsent(ViewContext context)
        {
            return context.ViewBag.AskCookieConsent ?? false;
        }

        public static bool HasCookieConsent(ViewContext context)
        {
            return context.ViewBag.HasCookieConsent ?? false;
        }
    }
}