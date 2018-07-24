using API.Models;
using Koombu.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Koombu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(/*EnvironmentVariableTarget groupName*/)
        {
            if(SessionManager.GetUser() != null)
            {
                int id = SessionManager.GetUser().Id;
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("userId", id.ToString());
                headers.Add("userPass", SessionManager.GetUser().Password);
                String fluxResult = WWWFetcher.Get("http://localhost:8080/api/flux/user/"+ id, headers);
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(fluxResult);
                ViewBag.Posts = posts;
                ViewBag.UserId = id;
                String groupResult = WWWFetcher.Get("http://localhost:8080/api/users/" + id, headers);
                User user = JsonConvert.DeserializeObject<User>(groupResult);
                ViewBag.Groups = user.groups;




                return View();
            }
            return RedirectToAction("Index", "LandingPage");
            

        }


    }
}