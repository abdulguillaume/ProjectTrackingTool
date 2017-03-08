using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class InMemoryDBContextInitializer : DropCreateDatabaseIfModelChanges<InMemoryDBContext>//DropCreateDatabaseAlways<InMemoryDBContext>
    {
        private void Init(InMemoryDBContext context) 
        {

            context.task_priorities.AddRange(
                
                new List<TaskPriority>{
                    new TaskPriority { Priority_Id=1, Priority_Name ="Low" },
                    new TaskPriority { Priority_Id=2, Priority_Name ="Medium" },
                    new TaskPriority { Priority_Id=1, Priority_Name ="High" }
                }
            );

            context.task_status.AddRange(

                new List<TaskStatus>{
                    new TaskStatus { Status_Id=1, Status_Name ="ToDo" },
                    new TaskStatus { Status_Id=2, Status_Name ="InProgress" },
                    new TaskStatus { Status_Id=3, Status_Name ="RFC/Review" },
                    new TaskStatus { Status_Id=4, Status_Name ="Done" }
                }
            );

            context.contact_types.AddRange(

                new List<ContactType>{
                    new ContactType { Contact_Type_Id=1, Contact_Type_Name ="Tel" },
                    new ContactType { Contact_Type_Id=2, Contact_Type_Name ="Email" }
                }
            );

            context.customer_types.AddRange(

               new List<CustomerType>{
                    new CustomerType { Customer_Type_Id=1, Customer_Type_Name ="Person" },
                    new CustomerType { Customer_Type_Id=2, Customer_Type_Name ="Company/Org." }
                }
           );

            context.SaveChanges();

        }

        protected override void Seed(InMemoryDBContext context)
        {
            Init(context);
        }


    }
}