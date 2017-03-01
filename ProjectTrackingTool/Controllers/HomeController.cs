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
        private InMemoryDBContext context;

        public HomeController()
        {
            context = new InMemoryDBContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            TaskPriority atask = context.Set<TaskPriority>().Find(1);

            ViewBag.Message = atask.Priority_Name;//"Your contact page.";

            return View();
        }
    }
}