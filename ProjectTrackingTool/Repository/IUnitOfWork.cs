using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackingTool.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerRepository customers { get; }
        IProjectRepository projects { get; }

        IContactInfoRepository contactInfo { get; }

        ITaskPriorityRepository priorities { get; }
        
        ITaskStatusRepository taskStatus { get; }

        IContactTypeRepository contactTypes { get; }

        ICustomerTypeRepository customerTypes { get; }

        
        
        int Complete();
    }
}
