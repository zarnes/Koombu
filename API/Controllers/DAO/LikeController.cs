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
    public class LikesController : Controller
    {
        private readonly DbAPIContext context;

        public LikesController(DbAPIContext context)
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

        // GET api/likes
        [HttpGet]
        public IEnumerable<Like> Get()
        {
            return context.Likes;
        }

        // GET api/likes/5
        [HttpGet("{id}")]
        public Like Get(int id)
        {
            return context.Likes.Find(id);
        }

        // POST api/likes
        [HttpPost]
        public bool Post([FromBody]Like like)
        {
            // Check auth
            if (!Authenticate())
                return false;

            // Check if like's userId is valid
            if (like.UserId != int.Parse(Request.Headers["userId"]))
                return false;

            // Modify like
            if (like.Id != 0)
            {
                Like lk = context.Likes.Find(like.Id);
                if (lk != null)
                {
                    lk.Copy(like);
                    context.SaveChanges();
                    return true;
                }
            }

            // If user already like this post
            if (context.Likes.Any(l => l.PostId == like.PostId && l.UserId == like.UserId))
                return false;

            // Create new like
            context.Likes.Add(like);
            context.SaveChanges();
            return true;
        }

        // PUT api/likes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/likes/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Like like = context.Likes.Find(id);
            if (like != null)
            {
                context.Likes.Remove(like);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
