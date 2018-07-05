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
    public class LandingPageController : Controller
    {
        // GET: LandingPage
        public ActionResult Index()
        {

            //string result = WWWFetcher.Get("http://localhost:8080/api/users/auth");
            User user = JsonConvert.DeserializeObject<User>(result);
            JsonConvert.SerializeObject(user);
            return View();
        }
    }
}