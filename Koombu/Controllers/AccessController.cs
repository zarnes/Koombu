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

            var Email = Request.QueryString["email"];
            var Psw = Request.QueryString["Password"];
            if (Email == null || Psw == null)
            {
                return View();
            }
            else
            {
                //verifier les identifiant
            }
            return RedirectToAction("Index", "Home");
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
                //verifier les identifiant
                //if identifiant exist creer $session user
                //redirection to home page

            }
            return RedirectToAction("Index", "Home");
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
            String brth = Convert.ToString(form["brth"]);
            String titre = Convert.ToString(form["titre"]);
            String company = Convert.ToString(form["company"]);
            String psw = Convert.ToString(form["psw"]);

            // add user to th bd
            return RedirectToAction("Index", "LandingPage"); 
        }
        public ActionResult Deconnexion()
        {

            return RedirectToAction("Index", "LandingPage");
        }
    }
}