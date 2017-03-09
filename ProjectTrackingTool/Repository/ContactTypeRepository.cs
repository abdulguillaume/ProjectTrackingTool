using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class ContactTypeRepository:Repository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}