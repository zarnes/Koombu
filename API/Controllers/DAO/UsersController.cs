using API.Models;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DbAPIContext context;

        public UsersController(DbAPIContext context)
        {
            this.context = context;
        }

        private int RequestUserId
        {
            get { return int.Parse(Request.Headers["userId"]); }
        }

        private bool Authenticate()
        {
            string id = Request.Headers["userId"];
            string password = Request.Headers["userPass"];

            return Authentifier.Authenticate(id, password);
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            if (!Authenticate())
                return null;

            return context.Users;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            if (!Authenticate())
                return null;

            User usr = context.Users.Find(id);
            usr.GetLinkedInformations();
            return usr;
        }

        // POST api/users
        [HttpPost]
        public bool Post([FromBody]User user)
        {
            if (!user.IsValid)
                return false;

            if (user.Id != 0)
            {
                User usr = context.Users.Find(user.Id);
                if (usr != null)
                {
                    usr.Copy(user);
                    context.SaveChanges();
                    return true;
                }
            }

            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (!Authenticate())
                return false;

            User user = context.Users.Find(id);
            if (user != null && user.Id != int.Parse(Request.Headers["userId"]))
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpGet("Auth")]
        public bool TestAuth()
        {
            return true;
        }
    }
}
