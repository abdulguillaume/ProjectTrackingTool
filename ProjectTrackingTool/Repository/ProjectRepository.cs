using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Repository
{
    public class ProjectRepository: Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectContext context)
            : base(context)
        {

        }

        public IEnumerable<Project> GetProjectsByStatus(int pageIndex, int pageSize)
        {
            return context.projects
                .Include("status")
                .Include("priority")
                .Include("Client")
                .OrderBy(x=>x.status.Status_Id) //to change to order by priority when adding the related field;
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}