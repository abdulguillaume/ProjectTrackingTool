using ProjectTrackingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingTool.Repository
{
    public interface IProjectRepository: IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByStatus(int pageIndex, int pageSize);
    }
}
