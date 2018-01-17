using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Core.Interfaces
{
    public interface IAuditTrail
    {
        /// <summary>
        /// Recording time against created entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime _CreatedUtc { get; set; }

        /// <summary>
        /// Recording user against created entity.
        /// </summary>
        /// <returns></returns>
        string _CreatedBy { get; set; }

        /// <summary>
        /// Recording user agent against created entity.
        /// </summary>
        /// <returns></returns>
        string _CreatedAgent { get; set; }

        /// <summary>
        /// Recording time against modified entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime _LastModifiedUtc { get; set; }

        /// <summary>
        /// Recording user against modified entity.
        /// </summary>
        /// <returns></returns>
        string _LastModifiedBy { get; set; }

        /// <summary>
        /// Recording user agent against modified entity.
        /// </summary>
        /// <returns></returns>
        string _LastModifiedAgent { get; set; }
    }

    public interface ISoftDelete
    {
        /// <summary>
        /// Flagging deleted entity.
        /// </summary>
        /// <returns>Boolean</returns>
        bool _IsDeleted { get; set; }

        /// <summary>
        /// Recording time against deleted entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime _DeletedUtc { get; set; }

        /// <summary>
        /// Recording user against deleted entity. 
        /// </summary>
        /// <returns></returns>
        string _DeletedBy { get; set; }

        /// <summary>
        /// Recording user agent against deleted entity. 
        /// </summary>
        /// <returns></returns>
        string _DeletedAgent { get; set; }
    }
}
