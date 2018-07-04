using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController
    {
        private readonly DbAPIContext context;

        public CommentsController(DbAPIContext context)
        {
            this.context = context;
        }

        // GET api/comments
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return context.Comments;
        }

        // GET api/comments/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return context.Comments.Find(id);
        }

        // POST api/comments
        [HttpPost]
        public void Post([FromBody]Comment comment)
        {
            if (comment.Id != 0)
            {
                Comment cmt = context.Comments.Find(comment.Id);
                if (cmt != null)
                {
                    cmt.Copy(comment);
                    context.SaveChanges();
                    return;
                }
            }

            context.Comments.Add(comment);
            context.SaveChanges();
        }

        // PUT api/comments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Comment comment = context.Comments.Find(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
