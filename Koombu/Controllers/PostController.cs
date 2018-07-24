using API.Models;
using Koombu.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koombu.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPost()
        {
            var postTitle = Request["postTitle"];
            var postImg = Request["postImg"];
            var postFile = Request["postFile"];
            var postText = Request["postText"];
            var groupId = Request["groupId"];


            int id = SessionManager.GetUser().Id;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("userId", id.ToString());
            headers.Add("userPass", SessionManager.GetUser().Password);
            Post post = new Post()
            {
                Title = postTitle,
                Content= postText,
                Picture = postImg,
                Attachment = postFile,
                GroupId = int.Parse(groupId),

            };
            String fluxResult = WWWFetcher.Post("http://localhost:8080/api/posts", JsonConvert.SerializeObject(post), headers);
            return null;
        }
    }
}