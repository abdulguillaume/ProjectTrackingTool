using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class ContactInfoRepository: Repository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}