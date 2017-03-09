using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class CustomerTypeRepository:Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}