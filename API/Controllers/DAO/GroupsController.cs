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
    public class GroupsController : Controller
    {
        private readonly DbAPIContext context;

        public GroupsController(DbAPIContext context)
        {
            this.context = context;
        }

        private int RequestUserId
        {
            get { return int.Parse(Request.Headers["userId"]); }
        }

        private bool Authenticate()
        {
            if (Authentifier.context == null)
                Authentifier.context = context;

            string id = Request.Headers["userId"];
            string password = Request.Headers["userPass"];


            return Authentifier.Authenticate(id, password);
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
            Group group = context.Groups.Find(id);
            group.GetLinkedInformations();
            return group;
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

        [HttpPost("join")]
        public bool Join([FromBody]User_Group user_group)
        {
            // Not authentified
            if (!Authenticate())
                return false;

            // Quit if another user
            if (user_group.UserId != RequestUserId)
                return false;


            // Already in group, updating rank
            User_Group uGroup = context.User_Groups.FirstOrDefault(ug => ug.GroupId == user_group.GroupId && ug.UserId == user_group.GroupId);
            if (uGroup != null)
            {
                uGroup.IsAdmin = user_group.IsAdmin;
            }

            // Check if group exist
            if (!context.Groups.Any(g => g.Id == user_group.GroupId))
                return false;

            // Joining group
            context.User_Groups.Add(user_group);
            context.SaveChanges();
            
            return true;
        }

        [HttpGet("quit/{id}")]
        public bool Quit(int groupId)
        {
            var path = Request.Path;
            string[] splitted = path.Value.Split('/');
            groupId = int.Parse(splitted.Last());
            // Not authentified
            if (!Authenticate())
                return false;

            // Remove user from group if he is
            User_Group uGroup = context.User_Groups.FirstOrDefault(ug => ug.GroupId == groupId && ug.UserId == RequestUserId);
            if (uGroup != null)
            {
                context.User_Groups.Remove(uGroup);
                context.SaveChanges();
            }

            return true;
        }
    }
}
