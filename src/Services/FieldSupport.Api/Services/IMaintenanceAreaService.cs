using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure;
using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Api.Services
{
    public interface IMaintenanceAreaService : IBaseFacade<MaintenanceArea, MaintenanceAreaSearchContext>
    {
    }

    public class MaintenanceAreaSearchContext : SearchContext
    {
    }

    public class MaintenanceAreaService : BaseFacade<MaintenanceArea, MaintenanceAreaSearchContext>
    {
        public MaintenanceAreaService(FieldSupportContext context) : base(context)
        {
        }

        public override IQueryable<MaintenanceArea> SearchQuery(MaintenanceAreaSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}
