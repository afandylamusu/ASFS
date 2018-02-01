using Astra.Core.Interfaces;

namespace FieldSupport.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketSearchContext : ISearchContext
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Index { get; set; }
    }
}