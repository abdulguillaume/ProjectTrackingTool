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

        //public IUnitOfWork mockUnitOfWork()
        /* {
             var con1 = new ContactType { Contact_Type_Id=1, Contact_Type_Name ="Tel" };
             var con2 = new ContactType { Contact_Type_Id=2, Contact_Type_Name ="Email" };

             var contactTypes = new List<ContactType>{
                     con1, con2
                 };

             var cus1 = new CustomerType { Customer_Type_Id=1, Customer_Type_Name ="Person" };
             var cus2 = new CustomerType { Customer_Type_Id=2, Customer_Type_Name ="Company/Org." };

         new CustomerType { Customer_Type_Id=1, Customer_Type_Name ="Person" },
             new CustomerType { Customer_Type_Id=2, Customer_Type_Name ="Company/Org." } 
        
             var customerTypes = new List<CustomerType>{
                     cus1, cus2
                 };

             var cinfo1 = new ContactInfo { Contact_Info_Id = 1, type= con1, detail = "+1305" };
             var cinfo2 = new ContactInfo { Contact_Info_Id = 2, type = con2, detail = "abdul@arimex.ht" };
             var cinfo3 = new ContactInfo { Contact_Info_Id = 3, type = con1, detail = "+509" };

             var contactInfo = new List<ContactInfo>{
                     cinfo1, cinfo2, cinfo3
                 };


             var customers = new List<Customer>
             {
                 new Customer{Customer_Id=1, Customer_Name="FB", Contact_Name="Marc", Customer_Type=cus1, Contact_Info = new List<ContactInfo>{cinfo2, cinfo3}},

                 new Customer{Customer_Id=2, Customer_Name="Arimex", Contact_Name="Dof", Customer_Type=cus2, Contact_Info = new List<ContactInfo>{cinfo1}}
             };

             //var unitOfWork = new UnitOfWork(new Mock<ProjectContext>().Object);

             //unitOfWork.Setup(e => e.customers.GetCustomers(1, 20)).Returns(customers);
            

             //UnitOfWork(new Mock<ProjectContext>().Object);

             //return unitOfWork;
         } 
         */
        List<Customer> customers = new List<Customer>
            {
                new Customer{Customer_Id=1, Customer_Name="FB", Contact_Name="Marc"},

                new Customer{Customer_Id=2, Customer_Name="Arimex", Contact_Name="Dof"}
            };

        [TestMethod]
        public void Index()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            CustomerController controller = new CustomerController(mock.Object);
            mock.Setup(x => x.customers.GetCustomers(1, 20)).Returns(customers);

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
            var mock = new Mock<IUnitOfWork>();
            CustomerController controller = new CustomerController(mock.Object);

            //var mockCustType = new Mock<IUnitOfWork>();
            mock.Setup(x => x.customerTypes.GetAll()).Returns(

                new List<CustomerType>{
                    new CustomerType { Customer_Type_Id=1, Customer_Type_Name ="Person" },
                 new CustomerType { Customer_Type_Id=2, Customer_Type_Name ="Company/Org." } 
                }

            );

            //var mockContType = new Mock<IUnitOfWork>();
            mock.Setup(x => x.contactTypes.GetAll()).Returns(

                new List<ContactType>{
                    new ContactType { Contact_Type_Id=1, Contact_Type_Name ="Tel" },
                 new ContactType { Contact_Type_Id=2, Contact_Type_Name ="Email" } 
                }

            );


            // Act
            ViewResult result = controller.Create() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void addDepToCustomer_Test()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            CustomerController controller = new CustomerController(mock.Object);

            //var mockCustType = new Mock<IUnitOfWork>();
            mock.Setup(x => x.customerTypes.GetAll()).Returns(

                new List<CustomerType>{
                    new CustomerType { Customer_Type_Id=1, Customer_Type_Name ="Person" },
                 new CustomerType { Customer_Type_Id=2, Customer_Type_Name ="Company/Org." } 
                }

            );

            //var mockContType = new Mock<IUnitOfWork>();
            mock.Setup(x => x.contactTypes.GetAll()).Returns(

                new List<ContactType>{
                    new ContactType { Contact_Type_Id=1, Contact_Type_Name ="Tel" },
                 new ContactType { Contact_Type_Id=2, Contact_Type_Name ="Email" } 
                }

            );


            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        
        }
    }
}
