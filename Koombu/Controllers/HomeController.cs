using Koombu.Utilities;
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
                string result = WWWFetcher.Get("http://localhost:8080/api/users/1", headers);

                return View();
            }
            return RedirectToAction("Index", "LandingPage");
            

        }


    }
}