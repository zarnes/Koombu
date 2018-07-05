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
    public class CommentsController : Controller
    {
        private readonly DbAPIContext context;

        public CommentsController(DbAPIContext context)
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
        public bool Post([FromBody]Comment comment)
        {
            if (!Authenticate())
                return false;

            // Checking comment validity
            if (!comment.IsValid)
                return false;
            if (!context.Users.Any(u => u.Id == comment.UserId))
                return false;
            if (!context.Posts.Any(p => p.Id == comment.PostId))
                return false;

            if (comment.Id != 0)
            {
                Comment cmt = context.Comments.Find(comment.Id);
                if (cmt != null)
                {
                    cmt.Copy(comment);
                    context.SaveChanges();
                    return true;
                }
            }

            context.Comments.Add(comment);
            context.SaveChanges();
            return true;
        }

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (!Authenticate())
                return false;

            Comment comment = context.Comments.Find(id);

            // Validation
            if (comment == null)
                return false;
            if (comment.UserId != RequestUserId)
                return false;
            
            context.Comments.Remove(comment);
            context.SaveChanges();
            return true;
        }
    }
}
