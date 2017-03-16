using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class AStatusRepository:Repository<AStatus>, IAStatusRepository
    {
        public AStatusRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}