using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomers(int pageIndex, int pageSize);
    }
}