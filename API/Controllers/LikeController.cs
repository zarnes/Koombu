using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class LikesController
    {
        private readonly DbAPIContext context;

        public LikesController(DbAPIContext context)
        {
            this.context = context;
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
        public void Post([FromBody]Like like)
        {
            if (like.Id != 0)
            {
                Like lk = context.Likes.Find(like.Id);
                if (lk != null)
                {
                    lk.Copy(like);
                    context.SaveChanges();
                    return;
                }
            }

            context.Likes.Add(like);
            context.SaveChanges();
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
