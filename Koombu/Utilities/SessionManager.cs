using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu.Utilities
{
    public class SessionManager
    {
        private static void Set(string index, object value)
        {
            HttpContext.Current.Session[index] = value;
        }

        private static object Get(string index)
        {
            return HttpContext.Current.Session[index];
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