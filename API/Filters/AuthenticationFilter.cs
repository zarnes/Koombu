﻿using API.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Filters
{
    public class AuthenticationFilter
    {
        public static bool Authenticate(DbAPIContext context, int id, string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            User user = context.Users.Find(id);
            if (user == null)
                return false;
            else if (user.Password != password)
                return false;
            else
                return true;
        }
    }
}
