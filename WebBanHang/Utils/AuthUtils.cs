﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebBanHang.Utils
{
    public static class AuthUtils
    {
        public static int SetAuthCookie(this HttpResponseBase responseBase,String cookieName, bool rememberMe, object userData)
        {

            /// In order to pickup the settings from config, we create a default cookie and use its values to create a 
            /// new one.
            var cookie = FormsAuthentication.GetAuthCookie(cookieName, rememberMe);
            cookie.Name = cookieName;
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,
                ticket.IsPersistent, js.Serialize(userData), ticket.CookiePath);
            var encTicket = FormsAuthentication.Encrypt(newTicket);

            /// Use existing cookie. Could create new one but would have to copy settings over...
            cookie.Value = encTicket;

            responseBase.Cookies.Add(cookie);

            return encTicket.Length;
        }
    }
}