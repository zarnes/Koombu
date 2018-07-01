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
            return RedirectToAction("Index", "Home");
        }
    }
}