using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Api.Services
{
    public interface IMaintenanceGroupService : IBaseFacade<MaintenanceGroup, MaintenanceGroupSearchContext>
    {
    }

    public class MaintenanceGroupSearchContext : SearchContext
    {
    }

    public class MaintenanceGroupService : BaseFacade<MaintenanceGroup, MaintenanceGroupSearchContext>, IMaintenanceGroupService
    {
        public MaintenanceGroupService(DbContext context) : base(context)
        {
        }

        public override IQueryable<MaintenanceGroup> SearchQuery(MaintenanceGroupSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}
