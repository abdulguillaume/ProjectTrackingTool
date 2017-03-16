using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext context;

        public UnitOfWork(ProjectContext context)
        {
            this.context = context;

            customers = new CustomerRepository(context);
            contactInfo = new ContactInfoRepository(context);
            projects = new ProjectRepository(context);

            //static data
            priorities = new TaskPriorityRepository(context);
            statuses = new AStatusRepository(context);
            customerTypes = new CustomerTypeRepository(context);
            contactTypes = new ContactTypeRepository(context);
        }
        
        public int Complete()
        {
            return context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
            //throw new NotImplementedException();
        }

        public ICustomerRepository customers
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public IProjectRepository projects
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public ITaskPriorityRepository priorities
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public IAStatusRepository statuses
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public IContactTypeRepository contactTypes
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public ICustomerTypeRepository customerTypes
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        public IContactInfoRepository contactInfo
        {
            get;
            private set;
            //get { throw new NotImplementedException(); }
        }

        
    }
}