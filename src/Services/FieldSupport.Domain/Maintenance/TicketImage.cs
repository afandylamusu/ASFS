using Astra.Core.SharedKernel;
using FieldSupport.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Domain.Maintenance
{
    public class TicketImage : BaseEntity
    {
        public virtual Ticket Ticket { get; set; }
        public int Ticket_Id { get; set; }

        public virtual ImageInfo Image { get; set; }
        public int Image_Id { get; set; }

    }
}
