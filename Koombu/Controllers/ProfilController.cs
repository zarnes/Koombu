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
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            string id = SessionManager.GetUser().Id.ToString();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("userId", id);
            headers.Add("userPass", SessionManager.GetUser().Password);            
            String groupResult = WWWFetcher.Get("http://localhost:8080/api/users/" + id, headers);
            User user = JsonConvert.DeserializeObject<User>(groupResult);
            String postsResult = WWWFetcher.Get("http://localhost:8080/api/flux/user/" + id, headers);
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(postsResult);
            ViewBag.Groups = user.groups;
            ViewBag.Posts = posts;
            return View();
        }
    }
}