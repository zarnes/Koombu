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

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Deconnexion()
        {

            return RedirectToAction("Index", "LandingPage");
        }
    }
}