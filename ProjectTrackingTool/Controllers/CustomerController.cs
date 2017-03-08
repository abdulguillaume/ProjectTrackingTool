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
        private UnitOfWork unitOfWork;

        public CustomerController()
        {
            unitOfWork = new UnitOfWork(
                    new ProjectContext()
                );
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = unitOfWork.customers.GetAll();
           // Response.ContentType = "text/HTML";
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = unitOfWork.customers.Find(x => x.Customer_Id == id).FirstOrDefault();

            return View(customer);
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
        public ActionResult Create(Customer customer, int[] selectedCustomerType, int[] selectedContactType, string[] inputContactInfo)
        {
            ViewBag.CustomerTypes = unitOfWork.customerTypes.GetAll();//.getCustomerTypes();
            ViewBag.ContactTypes = unitOfWork.contactTypes.GetAll();//.getContactTypes();

            int[] contactInfoID = Enumerable.Repeat(0, selectedContactType.Length).ToArray();

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    addDepToCustomer(unitOfWork, customer, selectedCustomerType, selectedContactType, contactInfoID, inputContactInfo);

                    unitOfWork.customers.Add(customer);
                    unitOfWork.Complete();
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View(customer);
            }

            return View(customer);
        }

        private void addDepToCustomer(UnitOfWork ctxt, Customer customer, int[] selectedCustomerType, int[] selectedContactType, int[] contactInfoID, string[] inputContactInfo)
        {
            //attach a new customer type only if it has changed.
            if (customer.Customer_Type==null || customer.Customer_Type.Customer_Type_Id != selectedCustomerType[0])
            {
                CustomerType customer_type = unitOfWork.customerTypes.Get(selectedCustomerType[0]);//.getCustomerTypes().Where(x => x.Customer_Type_Id == selectedCustomerType[0]).FirstOrDefault();
                customer.addCustomerType(customer_type);
            }
            
            
            //remove unused ones
            if (customer.Contact_Info != null)
            {
                Func<ContactInfo, bool> lambda = x => x.Contact_Info_Id > 0 && !contactInfoID.Contains(x.Contact_Info_Id);

                ctxt.contactInfo.RemoveRange(
                        customer.Contact_Info.Where(lambda)
                    );

                //((ProjectContext)ctxt).contact_info.RemoveRange(
                //        customer.Contact_Info.Where(lambda)
                //    );

            }      

            int cnt = 0;

            //To add the new entries only.
            //Old contact info are already in the context
            //and can be updated anytime.
            List<ContactInfo> info = new List<ContactInfo>();

            ContactType contact_type_ = unitOfWork.contactTypes.Get(selectedContactType[cnt]);//.getContactTypes().Where(x => x.Contact_Type_Id == selectedContactType[cnt]).FirstOrDefault();

            foreach (var contact_type in selectedContactType)
            {
                
                ContactInfo contact_info;
                
                //if 0 means its a new contact info
                if (contactInfoID[cnt] == 0)
                { 
                    contact_info = new ContactInfo(); 
                }
                else //Get the old value of the contact info in the context
                {
                    contact_info = customer.Contact_Info.Where(x => x.Contact_Info_Id == contactInfoID[cnt]).FirstOrDefault(); 
                   // contact_info = context.contact_info.Where(x => x.Contact_Info_Id == contactInfoID[cnt]).FirstOrDefault(); 
                }

                //whether new or old, update info detail
                contact_info.detail = inputContactInfo[cnt];

                //if contact type has changed, attach the new one to contact info object
                //if new contact info, attach contact type
                if (contactInfoID[cnt] == 0 || (contactInfoID[cnt] > 0 && customer.Contact_Info[cnt].type.Contact_Type_Id != selectedContactType[cnt]))
                {
                    contact_info.addContactType(contact_type_);
                }
                //else, old contact type is saved (contact info detail updated already)


                if (contactInfoID[cnt] == 0)
                    info.Add(contact_info);

                cnt++;
            }  

            if(info.Count>0)
                customer.addContactInfo(info);
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
        public ActionResult Edit(int id, Customer customer, int[] selectedCustomerType, int[] selectedContactType, int[] contactInfoID, string[] inputContactInfo)
        {
            var customer_ = unitOfWork.customers.Get(id);//.Where(x => x.Customer_Id == id).FirstOrDefault();

            ViewBag.CustomerTypes = unitOfWork.customerTypes.GetAll();//.getCustomerTypes();
            ViewBag.ContactTypes = unitOfWork.contactTypes.GetAll();//.getContactTypes();

            var contact_info = customer.Contact_Info;

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    customer_.Customer_Name = customer.Customer_Name;

                    customer_.Contact_Name = customer.Contact_Name;
           
                    addDepToCustomer(unitOfWork,customer_, selectedCustomerType, selectedContactType, contactInfoID, inputContactInfo);

                    //UpdateModel(customer_);
                    unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
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
