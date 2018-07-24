using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu.Utilities
{
    public class SessionManager
    {
        private static System.Web.SessionState.HttpSessionState Session;
        /*private static System.Web.SessionState.HttpSessionState SharedSession
        {
            get
            {
                return System.Web.HttpContext.Current.Session;
            }
        }*/

        private static void Set(string index, object value)
        {
            if (Session == null) Session = HttpContext.Current.Session;
            Session[index] = value;
        }

        private static object Get(string index)
        {
            if (Session == null) Session = HttpContext.Current.Session;
            return Session[index];
        }

        public static void SetUser(User user)
        {
            Set("User", user);
        }

        public static User GetUser()
        {
            return Get("User") as User;
        }
    }
}