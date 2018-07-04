using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController
    {
        private readonly DbAPIContext context;

        public PostsController(DbAPIContext context)
        {
            this.context = context;
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
            return context.Posts.Find(id);
        }

        // POST api/posts
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            if (post.Id != 0)
            {
                Post pt = context.Posts.Find(post.Id);
                if (pt != null)
                {
                    pt.Copy(post);
                    context.SaveChanges();
                    return;
                }
            }

            context.Posts.Add(post);
            context.SaveChanges();
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
                context.Posts.Remove(post);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
