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
    public class PostsController : Controller
    {
        private readonly DbAPIContext context;

        public PostsController(DbAPIContext context)
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

        // GET api/posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return context.Posts;
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            Post post = context.Posts.Find(id);
            post.GetLinkedInformations();
            return post;
        }

        // POST api/posts
        [HttpPost]
        public bool Post([FromBody]Post post)
        {
            if (!Authenticate())
                return false;
            
            // Post validation
            if (!post.IsValid)
                return false; // If the local values are incoherents
            if (RequestUserId != post.UserId)
                return false; // If the post's userId is incorrect
            if (!context.Users.Any(u => u.Id == post.UserId))
                return false; // If the user doesn't exists
            if (!context.Groups.Any(g => g.Id == post.GroupId))
                return false; // If the group doesn't exists
            if (!context.User_Groups.Any(ug => ug.UserId == post.UserId && ug.GroupId == post.GroupId))
                return false; // If the user is not in group
            
            if (post.Id != 0)
            {
                Post pt = context.Posts.Find(post.Id);
                if (pt != null)
                {
                    pt.Copy(post);
                    context.SaveChanges();
                    return true;
                }
            }
            
            context.Posts.Add(post);
            context.SaveChanges();
            return true;
        }

        // PUT api/posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            
            Post post = context.Posts.Find(id);
            if (post != null)
            {
                int userId = int.Parse(Request.Headers["userId"]);
                if (userId != post.UserId)
                    return false;

                context.Posts.Remove(post);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
