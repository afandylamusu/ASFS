using Astra.Core.SharedKernel;

namespace FieldSupport.Domain.Maintenance
{
    public class MaintenanceAreaDetail : BaseEntity
    {
        public string Name { get; set; }

        public virtual MaintenanceArea Area { get; set; }
        public int Area_Id { get; set; }
    }
}
