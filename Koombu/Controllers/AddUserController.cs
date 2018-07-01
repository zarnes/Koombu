using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koombu.Controllers
{
    public class AddUserController : Controller
    {
        // GET: AddUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            var FName = Request.QueryString["firstName"];
            var LName = Request.QueryString["lastName"];
            var Email = Request.QueryString["email"];
            var Brth = Request.QueryString["brth"];
            var Titre = Request.QueryString["titre"];
            var Company = Request.QueryString["company"];

            return RedirectToAction("Index", "LandingPage");
            
        }

    }
}