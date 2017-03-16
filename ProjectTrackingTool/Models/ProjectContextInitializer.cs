using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class ProjectContextInitializer : DropCreateDatabaseIfModelChanges<ProjectContext> //DropCreateDatabaseAlways<ProjectContext>
    {
        private void Init(ProjectContext context) 
        {

            context.priorities.AddRange(
                
                new List<APriority>{
                    new APriority { Priority_Id=1, Priority_Name ="High", cat=0 },
                    new APriority { Priority_Id=2, Priority_Name ="Medium", cat=0 },
                    new APriority { Priority_Id=3, Priority_Name ="Low", cat=0 }
                }
            );

            context.statuses.AddRange(

                new List<AStatus>{
                    new AStatus { Status_Id=1, Status_Name ="ToDo", cat=0 },
                    new AStatus { Status_Id=2, Status_Name ="InProgress", cat=0 },
                    new AStatus { Status_Id=3, Status_Name ="RFC/Review", cat=0 },
                    new AStatus { Status_Id=4, Status_Name ="Done", cat=0 }
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

        protected override void Seed(ProjectContext context)
        {
            Init(context);
        }


    }
}