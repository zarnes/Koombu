using API.Models;
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

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            if (user.Id != 0)
            {
                User usr = context.Users.Find(user.Id);
                if (usr != null)
                {
                    usr.Copy(user);
                    context.SaveChanges();
                    return;
                }
            }

            context.Users.Add(user);
            context.SaveChanges();
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
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
