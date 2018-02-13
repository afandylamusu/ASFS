using System.Data.Entity;

namespace MasterData.Data.Domain
{
    public class MenuItem : BaseEntity
    {
        public string Label { get; set; }
        public int RefId { get; set; }
        public string RefTypeName { get; set; }
    }
}
