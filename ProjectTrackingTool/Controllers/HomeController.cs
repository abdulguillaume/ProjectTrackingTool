using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTrackingTool.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext context;

        public HomeController()
        {
            context = new ProjectContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            APriority atask = context.Set<APriority>().Find(1);
            var t = atask.Priority_Name;
            ViewBag.Message = "In case of any issue.";

            return View();
        }
    }
}