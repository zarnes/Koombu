using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        private readonly DbAPIContext context;

        public GroupsController(DbAPIContext context)
        {
            this.context = context;
        }

        // GET api/groups
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return context.Groups;
        }

        // GET api/groups/5
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return context.Groups.Find(id);
        }

        // POST api/groups
        [HttpPost]
        public void Post([FromBody]Group group)
        {
            if (group.Id != 0)
            {
                Group grp = context.Groups.Find(group.Id);
                if (grp != null)
                {
                    grp.Copy(group);
                    context.SaveChanges();
                    return;
                }
            }

            context.Groups.Add(group);
            context.SaveChanges();
        }

        // PUT api/groups/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/groups/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Group group = context.Groups.Find(id);
            if (group != null)
            {
                context.Groups.Remove(group);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
