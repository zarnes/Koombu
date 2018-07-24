using API.Models;
using Koombu.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Koombu.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(int idGroup)
        {
            
            string id = SessionManager.GetUser().Id.ToString();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("userId", id);
            headers.Add("userPass", SessionManager.GetUser().Password);
            String fluxResult = WWWFetcher.Get("http://localhost:8080/api/groups/" + idGroup, headers);
            Group group = JsonConvert.DeserializeObject<Group>(fluxResult);
            ViewBag.Group = group;
            return View();
        }

        public ActionResult addGroup()
        {
            var name = Request["groupName"];
            var privat = Request["privacy"] == "private";
            int id = SessionManager.GetUser().Id;
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("userId", id.ToString());
            headers.Add("userPass", SessionManager.GetUser().Password);
            Group group = new Group()
            {
                Name = name,
                Private = privat,
                OwnerId = id,
            };
            String fluxResult = WWWFetcher.Post("http://localhost:8080/api/group" ,JsonConvert.SerializeObject(group), headers);

            return null;
        }

        public ActionResult addUserToGroup()
        {
            var fname = Request["firstName"];
            var lName = Request["lastName"];
            var gourpId = Request["groupId"];
            return null;
        }


    }
}