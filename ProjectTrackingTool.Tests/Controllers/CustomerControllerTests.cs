using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTrackingTool.Controllers;
using System.Web.Mvc;
using Moq;
using ProjectTrackingTool.Repository;
using ProjectTrackingTool.Models;
using System.Collections.Generic;

namespace ProjectTrackingTool.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTests
    {

        public IUnitOfWork mockIUnitOfWork()
        {
            ContactType con1 = new ContactType { Contact_Type_Id = 1, Contact_Type_Name = "Tel" };
            
            ContactType con2 = new ContactType { Contact_Type_Id = 2, Contact_Type_Name = "Email" };

            ContactInfo cinfo1 = new ContactInfo { Contact_Info_Id = 1, type = con1, detail = "+1305" };

            ContactInfo cinfo2 = new ContactInfo { Contact_Info_Id = 2, type = con2, detail = "abdul@arimex.ht" };
        
            ContactInfo cinfo3 = new ContactInfo { Contact_Info_Id = 3, type = con1, detail = "+509" };

            var contactInfo = new List<ContactInfo>
            {
                cinfo1, cinfo2, cinfo3
            };
 
            var contactTypes = new List<ContactType>{
                    new ContactType { Contact_Type_Id=1, Contact_Type_Name ="Tel" },
                 new ContactType { Contact_Type_Id=2, Contact_Type_Name ="Email" } 
                };

            CustomerType cus1 = new CustomerType { Customer_Type_Id = 1, Customer_Type_Name = "Person" };
            CustomerType cus2 = new CustomerType { Customer_Type_Id = 2, Customer_Type_Name = "Company/Org." };

            List<CustomerType> customerTypes = new List<CustomerType>{ cus1, cus2 };

            var customers = new List<Customer>
            {
                new Customer{Customer_Id=1, Customer_Name="FB", Contact_Name="Marc", Customer_Type = cus2, Contact_Info = new List<ContactInfo>{cinfo1}},
                new Customer{Customer_Id=2, Customer_Name="Arimex", Contact_Name="Dof"}
            };

            var mock = new Mock<IUnitOfWork>();

            mock.Setup(x => x.customers.GetCustomers(1, 20)).Returns(customers);

            mock.Setup(x => x.contactTypes.GetAll()).Returns(contactTypes);

            mock.Setup(x => x.customerTypes.GetAll()).Returns(customerTypes);

            mock.Setup(x => x.customers.Get(It.IsAny<int>())).Returns((int id) => (customers.ToArray())[id-1]);

            mock.Setup(x => x.customers.Add(It.IsAny<Customer>()));//.Returns((Customer c) => customers.Add(c));

            //mock RemoveRange function from repository
            mock.Setup(x => x.contactInfo.RemoveRange(It.IsAny<List<ContactInfo>>()));

            return mock.Object;
        }

        [TestMethod]
        public void Index()
        {

            // Arrange
            var mock = mockIUnitOfWork();
            CustomerController controller = new CustomerController(mock);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var customers_res = (List<Customer>)result.ViewData.Model;
            
            // Assert
            Assert.AreEqual(2, customers_res.Count);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var mock = mockIUnitOfWork();
            CustomerController controller = new CustomerController(mock);

            // Act
            ViewResult result = controller.Create() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void CreateHttpPost()
        {
            // Arrange
            var mock = mockIUnitOfWork();
            CustomerController controller = new CustomerController(mock);
            //ID of the Customer to Edit
            int id = 1;
            //customer object returned by html form and passed as a parameter to function
            Customer source = new Customer
            {
                Customer_Id = 3,
                Customer_Name = "Marc",
                Contact_Name = "Marc",
                Contact_Info = new List<ContactInfo> { 

                    new ContactInfo{Contact_Info_Id = 1, 
                                        type = new ContactType{ Contact_Type_Id = 1 }, 
                                        detail = "+1786"
                    },

                    new ContactInfo{Contact_Info_Id = 2, 
                                        type = new ContactType{ Contact_Type_Id = 2 }, 
                                        detail = "a@b.ht"
                    }
                },
                Customer_Type = new CustomerType { Customer_Type_Id = 1 }
            };

            // Act
            //ViewResult result = controller.Create(source) as ViewResult;
            var result = (RedirectToRouteResult)controller.Create(source);

            
            // Assert
            //Assert.AreEqual("Index", result.RouteValues["action"]);
            //Assert.AreEqual("Home", result.RouteValues["controller"]);

            //AreEqual("Home", result.RouteValues["controller"]) will return null if
            //if you call redirectAction like this: RedirectToAction("Index");
            //it will return a string if you call it like this:
            //RedirectToAction("Index", "Customer");

            //or use below
            Assert.IsTrue(
             result.RouteValues["action"].Equals("Index") 
             //&& result.RouteValues["controller"].Equals("Customer")
            );
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            var mock = mockIUnitOfWork();
            CustomerController controller = new CustomerController(mock);

            int id = 1;
            
            // Act
            ViewResult result = controller.Edit(id) as ViewResult;
            Customer customer = (Customer)result.ViewData.Model;

            // Assert
            Assert.IsNotNull(result);

        }


        //[TestMethod]
        //public void EditHttpPost()
        //{
        //    // Arrange
        //    var mock = mockIUnitOfWork();
        //    CustomerController controller = new CustomerController(mock);

        //    int id = 1;

        //    Customer source = 
        //    new Customer{Customer_Id=1, Customer_Name="FB", Contact_Name="Marc", Customer_Type = cus2, Contact_Info = new List<ContactInfo>{cinfo1}}

        //    // Act
        //    ViewResult result = controller.Edit(id, source) as ViewResult;
        //    Customer customer = (Customer)result.ViewData.Model;

        //    // Assert
        //    Assert.IsNotNull(result);

        //}

        [TestMethod]
        public void addDepToCustomer_Edit_AddNewContactInfo_And_ChangeCustomerName_And_CustomerType_Test()
        {
            // Arrange
            var mock = mockIUnitOfWork();

            CustomerController controller = new CustomerController(mock);

            //ID of the Customer to Edit
            int id = 1;
            //customer object returned by html form and passed as a parameter to function
            Customer source = new Customer
            {
                Customer_Id = id,
                Customer_Name = "Marc",
                Contact_Name = "Marc",
                Contact_Info = new List<ContactInfo> { 

                    new ContactInfo{Contact_Info_Id = 1, 
                                        type = new ContactType{ Contact_Type_Id = 1 }, 
                                        detail = "+1786"
                    },

                    new ContactInfo{Contact_Info_Id = 2, 
                                        type = new ContactType{ Contact_Type_Id = 2 }, 
                                        detail = "a@b.ht"
                    }
                },
                Customer_Type = new CustomerType { Customer_Type_Id = 1 }
            };

            //customer object retrieved from db context and passed as a parameter to function
            //db context will be mocked
            Customer dest_customer_table = mock.customers.Get(id);

            string old_customer_name = dest_customer_table.Customer_Name;

            int old_customer_type = dest_customer_table.Customer_Type.Customer_Type_Id;

            int old_contact_info_cnt = dest_customer_table.Contact_Info.Count;

            // Act
            controller.addDepToCustomer(dest_customer_table, source, mock.customerTypes.GetAll(), mock.contactTypes.GetAll());

            // Assert
            Assert.IsTrue(

                old_customer_name.Equals("FB") &&
                dest_customer_table.Customer_Name.Equals("Marc") &&
                        old_customer_type == 2 &&
                        dest_customer_table.Customer_Type.Customer_Type_Id == 1 &&
                            old_contact_info_cnt == 1 &&
                            dest_customer_table.Contact_Info.Count == 2
                );

        }

         [TestMethod]
        public void addDepToCustomer_Edit_RemoveContactInfo_Add_NewOne_Test()
        {
            // Arrange
            var mock = mockIUnitOfWork();

            CustomerController controller = new CustomerController(mock);

            //ID of the Customer to Edit
            int id = 1;
            //customer object returned by html form and passed as a parameter to function
            Customer source = new Customer
            {
                Customer_Id = id,
                Customer_Name = "tesla",
                Contact_Name = "Marc",
                Contact_Info = new List<ContactInfo> { 

                    new ContactInfo{Contact_Info_Id = 2, 
                                        type = new ContactType{ Contact_Type_Id = 2 }, 
                                        detail = "a@b.ht"
                    }
                },
                Customer_Type = new CustomerType { Customer_Type_Id = 2 }
            };

            //customer object retrieved from db context and passed as a parameter to function
            //db context will be mocked
            Customer dest_customer_table = mock.customers.Get(id);

            string old_customer_name = dest_customer_table.Customer_Name;

            int old_contact_info_cnt = dest_customer_table.Contact_Info.Count;

            int old_contact_info_id = dest_customer_table.Contact_Info[0].Contact_Info_Id;


            // Act
            controller.addDepToCustomer(dest_customer_table, source, mock.customerTypes.GetAll(), mock.contactTypes.GetAll());

            // Assert
            Assert.IsTrue(
                        old_contact_info_id == 1 &&
                        dest_customer_table.Contact_Info[0].Contact_Info_Id == 2 &&
                            old_contact_info_cnt == 1 &&
                            dest_customer_table.Contact_Info.Count == 1
                );

        }

         [TestMethod]
         public void addDepToCustomer_Edit_RemoveContactInfo_ZeroContactInfo_Test()
         {
             // Arrange
             var mock = mockIUnitOfWork();

             CustomerController controller = new CustomerController(mock);

             //ID of the Customer to Edit
             int id = 1;
             //customer object returned by html form and passed as a parameter to function
             Customer source = new Customer
             {
                 Customer_Id = id,
                 Customer_Name = "tesla",
                 Contact_Name = "Marc",
                 Customer_Type = new CustomerType { Customer_Type_Id = 2 }
             };

             //customer object retrieved from db context and passed as a parameter to function
             //db context will be mocked
             Customer dest_customer_table = mock.customers.Get(id);

             int old_contact_info_cnt = dest_customer_table.Contact_Info.Count;

             // Act
             controller.addDepToCustomer(dest_customer_table, source, mock.customerTypes.GetAll(), mock.contactTypes.GetAll());
             int new_contact_info_cnt = dest_customer_table.Contact_Info==null?0:dest_customer_table.Contact_Info[0].Contact_Info_Id;

             // Assert
             
             Assert.IsTrue(
                         old_contact_info_cnt == 1 &&
                          new_contact_info_cnt == 0
                 );

         }

    }
}
