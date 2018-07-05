using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Flux")]
    public class FluxController : Controller
    {
        private readonly DbAPIContext context;

        public FluxController(DbAPIContext context)
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

        [HttpGet("User/{id}")]
        public List<Post> User(int id)
        {
            if (!Authenticate())
                return null;
            /*if (RequestUserId != id)
                return null;*/

            List<int> groupsIds = context.User_Groups.Where(ug => ug.UserId == id).Select(ug => ug.GroupId).ToList();
            List<Post> matchedPosts = context.Posts.Where(p => groupsIds.Contains(p.GroupId)).ToList();

            foreach(Post post in matchedPosts)
            {
                post.GetLinkedInformations();
            }

            return matchedPosts;
        }

        [HttpGet("Group/{id}")]
        public List<Post> Group(int id)
        {
            if (!Authenticate())
                return null;

            if (!context.User_Groups.Any(ug => ug.UserId == RequestUserId && ug.GroupId == id))
                return null;

            List<Post> match = context.Posts.Where(p => p.GroupId == id).ToList();
            foreach (Post post in match)
            {
                post.GetLinkedInformations();
            }
            return match;
        }
    }
}