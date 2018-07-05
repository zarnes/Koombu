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
        public ActionResult Index(EnvironmentVariableTarget groupName)
        {
            if(SessionManager.GetUser() != null)
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("userId", SessionManager.GetUser().Id.ToString());
                headers.Add("userPass", SessionManager.GetUser().Password);
                String result = WWWFetcher.Get("http://localhost:8080/api/flux/user/"+ SessionManager.GetUser().Id.ToString(), headers);
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(result);
                ViewBag.Posts = posts;

                return View();
            }
            return RedirectToAction("Index", "LandingPage");
            

        }


    }
}