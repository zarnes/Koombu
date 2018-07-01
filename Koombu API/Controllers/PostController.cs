using Koombu_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Koombu_API.Controllers
{
    public class PostController : ApiController
    {
        // GET: api/Post
        public IEnumerable<Post> Get()
        {
            List<Post> posts = new List<Post>();
            for (int i = 0; i < 10; ++i)
            {
                /*posts.Add(new Post(
                    i,
                    i.ToString(),
                    "Content : " + i.ToString(),
                    i.ToString() + ".png",
                    i,
                    i,
                    i.ToString() + ".file"
                ));*/
            }

            return posts;
        }

        // GET: api/Post/5
        public Post Get(int id)
        {
            /*return new Post(
                    id,
                    id.ToString(),
                    "Content : " + id.ToString(),
                    id.ToString() + ".png",
                    id,
                    id,
                    id.ToString() + ".file"
                );*/
            return null;
        }

        // POST: api/Post
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Post/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Post/5
        public void Delete(int id)
        {
        }
    }
}
