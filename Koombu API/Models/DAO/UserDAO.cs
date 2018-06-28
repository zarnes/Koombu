using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models.DAO
{
    public class UserDAO
    {
        public UserDAO()
        {
            
        }

        public User GetUser(int id)
        {
            return new User()
            {
                Id = 1,
                LastName = "Doe",
                FirstName = "John"
            };
        }
    }
}