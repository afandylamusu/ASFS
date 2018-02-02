using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;
using FieldSupport.Domain.Location;
using System;

namespace FieldSupport.Domain.Maintenance
{
    public class Ticket : BaseEntity, IAuditTrail
    {
        /// <summary>
        /// Ticket Code/Number
        /// </summary>
        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        #region Options

        /// <summary>
        /// Expire time for ticket 
        /// </summary>
        public DateTime ExpiredUtc { get; set; }

        /// <summary>
        /// Indicate if ticket will have expiration.
        /// </summary>
        public bool CanExpired { get; set; }

        /// <summary>
        /// Which indicates whether the tickets have been readed by Engineer or not
        /// </summary>
        //public bool IsAssignToReaded { get; set; }

        /// <summary>
        /// Which indicates whether the tickets have been finished by Engineer or not
        /// </summary>
        //public bool IsAssignToFinished { get; set; }

        /// <summary>
        /// State of ticket
        /// </summary>
        public TicketState State { get; set; }
        #endregion

        #region Relations
        public virtual Address Address { get; set; }
        public int Address_Id { get; set; }

        /// <summary>
        /// Engineer or Employee who responsible to handle the ticket
        /// </summary>
        public virtual Engineer AssignTo { get; set; }
        public int? AssignTo_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual TicketType TicketType { get; set; }
        public int TicketType_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Owner { get; set; }
        public int Owner_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MaintenanceArea Area { get; set; }
        public int Area_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MaintenanceAreaDetail AreaDetail { get; set; }
        public int AreaDetail_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual MaintenanceGroup Group { get; set; }
        public int Group_Id { get; set; } 
        #endregion

        #region Audit
        public DateTime _CreatedUtc { get; set; }
        public string _CreatedBy { get; set; }
        public string _CreatedAgent { get; set; }

        public DateTime _LastModifiedUtc { get; set; }
        public string _LastModifiedBy { get; set; }
        public string _LastModifiedAgent { get; set; }
        #endregion
    }
}
