using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Helper
{
    public class StaticData
    {
        ProjectContext context;

        List<ContactType> contact_types;
        List<CustomerType> customer_types;
        List<APriority> task_priorities;
        List<AStatus> task_status;

        public StaticData(ProjectContext context)
        {
            this.context = context;

            contact_types = getContactTypes_();

            customer_types = getCustomerTypes_();

            task_priorities = getTaskPriorities_();

            task_status = getTaskStatus_();
        }

        List<ContactType> getContactTypes_() { return context.contact_types.ToList(); }

        List<CustomerType> getCustomerTypes_() { return context.customer_types.ToList(); }

        List<APriority> getTaskPriorities_() { return context.priorities.ToList(); }

        List<AStatus> getTaskStatus_() { return context.statuses.ToList(); }

        public List<ContactType> getContactTypes() { return contact_types; }

        public List<CustomerType> getCustomerTypes() { return customer_types; }

        public List<APriority> getTaskPriorities() { return task_priorities; }

        public List<AStatus> getTaskStatus() { return task_status; }

    }
}