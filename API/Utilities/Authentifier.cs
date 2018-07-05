using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Utilities
{
    public class Authentifier
    {
        public static DbAPIContext context;

        public static bool Authenticate(string id, string password)
        {
            if (id == null || password == null)
                return false;

            using (var db = new DbAPIContext())
            {
                User user = db.Users.Find(int.Parse(id));
                if (user != null)
                {
                    return user.Password == password;
                }
            }

                

            return false;
        }
    }
}
