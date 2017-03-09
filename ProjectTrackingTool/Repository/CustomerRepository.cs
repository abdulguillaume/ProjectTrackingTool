using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProjectContext context)
            : base(context)
        {

        }


        public IEnumerable<Customer> GetCustomers(int pageIndex, int pageSize)
        {
            //have to do it manually b/c there is no eager loading with List<>
            //https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
            //both Customer_Type, and Contact_Info.type
            //should be included if you want to navigate through them
            var customers = context.customers
                .Include("Customer_Type")
                .Include("Contact_Info.type")
                .OrderBy(x => x.Customer_Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return customers.ToList();

            //throw new NotImplementedException();
        }


    }
}