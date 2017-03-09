using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class TaskStatusRepository:Repository<TaskStatus>, ITaskStatusRepository
    {
        public TaskStatusRepository(ProjectContext context)
            : base(context)
        {

        }
    }
}