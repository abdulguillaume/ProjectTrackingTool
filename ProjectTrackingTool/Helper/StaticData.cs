using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Helper
{
    public class StaticData
    {
        InMemoryDBContext context;

        List<ContactType> contact_types;
        List<CustomerType> customer_types;
        List<TaskPriority> task_priorities;
        List<TaskStatus> task_status;

        public StaticData(InMemoryDBContext context)
        {
            this.context = context;

            contact_types = getContactTypes_();

            customer_types = getCustomerTypes_();

            task_priorities = getTaskPriorities_();

            task_status = getTaskStatus_();
        }

        List<ContactType> getContactTypes_() { return context.contact_types.ToList(); }

        List<CustomerType> getCustomerTypes_() { return context.customer_types.ToList(); }

        List<TaskPriority> getTaskPriorities_() { return context.task_priorities.ToList(); }

        List<TaskStatus> getTaskStatus_() { return context.task_status.ToList(); }

        public List<ContactType> getContactTypes() { return contact_types; }

        public List<CustomerType> getCustomerTypes() { return customer_types; }

        public List<TaskPriority> getTaskPriorities() { return task_priorities; }

        public List<TaskStatus> getTaskStatus() { return task_status; }

    }
}