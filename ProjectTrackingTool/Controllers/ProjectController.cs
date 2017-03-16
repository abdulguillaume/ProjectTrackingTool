using ProjectTrackingTool.Models;
using ProjectTrackingTool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTrackingTool.Controllers
{
    public class ProjectController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ProjectController()
            : this(new UnitOfWork(new ProjectContext()))
        { 
        
        }

        // GET: Project
        public ActionResult Index()
        {
            var projects = unitOfWork.projects.GetProjectsByStatus(1, 20);

            return View(projects);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            //ViewBag.statuses = unitOfWork.statuses.GetAll();
            ViewBag.priorities = unitOfWork.priorities.GetAll();

            ViewBag.customers = unitOfWork.customers.GetAll();

            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            List<AStatus> statuses = (List<AStatus>)unitOfWork.statuses.GetAll();
            List<APriority> priorities = (List<APriority>)unitOfWork.priorities.GetAll();

            try
            {
                // TODO: Add insert logic here
                Customer client = unitOfWork.customers.Get(project.Client.Customer_Id);
                project.Client = client;

                APriority priority = priorities.Where(x => x.Priority_Id == project.priority.Priority_Id).FirstOrDefault();
                project.priority = priority;

                project.status = unitOfWork.statuses.Get(1);
                

                unitOfWork.projects.Add(project);
                unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.statuses = statuses;
                ViewBag.priorities = priorities;

                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
