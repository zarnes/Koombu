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
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Connexion()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Connexion(FormCollection form)
        {
            string Email = Convert.ToString(form["email"]);
            string Psw = Convert.ToString(form["password"]);



            if (Email == null || Psw == null)
            {
                return View();
            }
            else
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("userMail", Email);
                headers.Add("userPass", Psw);
                string result = WWWFetcher.Get("http://localhost:8080/api/users/auth",headers);
                User user = JsonConvert.DeserializeObject<User>(result);
                if (user != null)
                {
                    SessionManager.SetUser(user);                    
                    return RedirectToAction("Index", "Home");
                }

            }
            return RedirectToAction("Connexion", "LandingPage");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            String firstName = Convert.ToString(form["firstName"]);
            String lastName = Convert.ToString(form["lastName"]);
            String email = Convert.ToString(form["email"]);
            DateTime brth = Convert.ToDateTime(form["brth"]);
            String titre = Convert.ToString(form["titre"]);
            String company = Convert.ToString(form["company"]);
            String psw = Convert.ToString(form["psw"]);

            User user = new User()
            {
                Password = psw,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = brth,
                Title = titre,
                Company = company,
                Mail = email,

            };

            

            String result =WWWFetcher.Post("http://localhost:8080/api/users", JsonConvert.SerializeObject(user),null);
            return RedirectToAction("Index", "LandingPage"); 
        }
        public ActionResult Deconnexion()
        {
            SessionManager.SetUser(null);
            return RedirectToAction("Index", "LandingPage");
        }
    }
}