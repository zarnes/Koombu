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
    [Route("api/Search")]
    public class SearchController : Controller
    {
        private readonly DbAPIContext context;

        public SearchController(DbAPIContext context)
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

        [HttpGet("User/{name}")]
        public List<User> User(string name)
        {
            if (!Authenticate())
                return null;
            
            List<User> matchedUsers = context.Users.Where(u => u.FullName.Like("%" + name + "%")).ToList();

            return matchedUsers;
        }

        [HttpGet("Post/{name}")]
        public List<Post> Post(string name)
        {
            if (!Authenticate())
                return null;

            List<Post> matchedPosts = context.Posts.Where(p => p.Content.Like("%" + name + "%") || p.Title.Like("%" + name + "%")).ToList();
            foreach(Post post in matchedPosts)
            {
                post.GetLinkedInformations();
            }
            return matchedPosts;
        }
    }
}