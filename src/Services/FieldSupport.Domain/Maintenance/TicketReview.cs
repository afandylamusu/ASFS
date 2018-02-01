using Astra.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Domain.Maintenance
{
    public class TicketReview : BaseEntity
    {
        public virtual Ticket Ticket { get; set; }
        public int Ticket_Id { get; set; }
    }
}
