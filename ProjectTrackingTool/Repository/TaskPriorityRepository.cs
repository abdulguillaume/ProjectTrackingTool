using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class TaskPriorityRepository:Repository<TaskPriority>, ITaskPriorityRepository
    {
        public TaskPriorityRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}