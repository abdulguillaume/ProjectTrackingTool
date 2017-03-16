using ProjectTrackingTool.Helper;
using ProjectTrackingTool.Models;
using ProjectTrackingTool.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTrackingTool.Controllers
{
    public class CustomerController : Controller
    {
        private IUnitOfWork unitOfWork;

        public CustomerController()
            :this( new UnitOfWork( new ProjectContext() ) )
        {

        }

        public CustomerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = unitOfWork.customers.GetCustomers(1, 20);
            //above query only cannot load all the related object to customer, b/c of there is no eager loading
            //once you transform the dbset to list, you lost all the relations
            //you need to do it manually.

           // Response.ContentType = "text/HTML";

            return View(customers);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.CustomerTypes = unitOfWork.customerTypes.GetAll();//.getCustomerTypes();
            ViewBag.ContactTypes = unitOfWork.contactTypes.GetAll();//.getContactTypes();

            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
              List<CustomerType> custTypes = unitOfWork.customerTypes.GetAll().ToList();
              List<ContactType> contTypes = unitOfWork.contactTypes.GetAll().ToList();

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    addDepToCustomer(customer, customer, custTypes, contTypes);

                    unitOfWork.customers.Add(customer);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                ViewBag.CustomerTypes = custTypes;
                ViewBag.ContactTypes = contTypes;

                return View(customer);
            }

            return View(customer);
        }

        public void addDepToCustomer(Customer dest, Customer source, IEnumerable<CustomerType> custTypes, IEnumerable<ContactType> contTypes)
        {
            if (dest.Customer_Id != source.Customer_Id) return;

            dest.Customer_Name = source.Customer_Name;

            dest.Contact_Name = source.Contact_Name;

            CustomerType cut = 
                custTypes.Where(x=>x.Customer_Type_Id==source.Customer_Type.Customer_Type_Id).First();

            dest.Customer_Type = cut;

            //remove deleted information from db context
            if (source.Contact_Info != null)
            {
                Func<ContactInfo, bool> lambda = x => x.Contact_Info_Id > 0 && !source.Contact_Info.Contains(x);

                IEnumerable<ContactInfo> tmp = dest.Contact_Info.Where(lambda);

                unitOfWork.contactInfo.RemoveRange(
                        tmp
                    );
            }

            if (source.Contact_Info == null)
            {
                dest.Contact_Info = null;
                return;
            }

            foreach (var info in source.Contact_Info)
            {
                ContactType cot = contTypes.Where(x => x.Contact_Type_Id == info.type.Contact_Type_Id).First();
                info.type = cot;
            }

            dest.Contact_Info = source.Contact_Info;
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = unitOfWork.customers.Get(id);//Where(x => x.Customer_Id == id).FirstOrDefault();

            ViewBag.CustomerTypes = unitOfWork.customerTypes.GetAll();//.getCustomerTypes();
            ViewBag.ContactTypes = unitOfWork.contactTypes.GetAll();//.getContactTypes();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            var customer_ = unitOfWork.customers.Get(id);

            //to avoid round trip to db
            List<CustomerType> custTypes = unitOfWork.customerTypes.GetAll().ToList();
            List<ContactType> contTypes = unitOfWork.contactTypes.GetAll().ToList();

            //var contact_info = customer.Contact_Info;

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    addDepToCustomer(customer_, customer, custTypes, contTypes);

                    unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                ViewBag.CustomerTypes = custTypes;
                ViewBag.ContactTypes = contTypes;
                return View(customer_);
            }

            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = unitOfWork.customers.Get(id);//(x => x.Customer_Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)//, Customer customer)
        {
            Customer customer = unitOfWork.customers.Get(id);//Where(x => x.Customer_Id == id).FirstOrDefault();
            
            bool result;

            try
            {
                // TODO: Add delete logic here
                //if (ModelState.IsValid)
                //{
                unitOfWork.contactInfo.RemoveRange(customer.Contact_Info);
                unitOfWork.customers.Remove(customer);

                unitOfWork.Complete();

                    result = true;
                    //return RedirectToAction("Index");
                //}
            }
            catch
            {
                result = false;
            }

            return Json(new {result}, JsonRequestBehavior.AllowGet);
        }
    }
}
