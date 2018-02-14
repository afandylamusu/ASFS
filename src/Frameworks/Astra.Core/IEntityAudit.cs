using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public interface IEntityHistory
    {
        /// <summary>
        /// Recording time against created entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Recording user against created entity.
        /// </summary>
        /// <returns></returns>
        string CreatedBy { get; set; }

        /// <summary>
        /// Recording user agent against created entity.
        /// </summary>
        /// <returns></returns>
        //string _CreatedAgent { get; set; }

        /// <summary>
        /// Recording time against modified entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Recording user against modified entity.
        /// </summary>
        /// <returns></returns>
        string ModifiedBy { get; set; }

        /// <summary>
        /// Recording user agent against modified entity.
        /// </summary>
        /// <returns></returns>
        //string _LastModifiedAgent { get; set; }
    }

    public interface IEntitySoftDelete
    {
        /// <summary>
        /// Flagging deleted entity.
        /// </summary>
        /// <returns>Boolean</returns>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Recording time against deleted entity. In UTC format
        /// </summary>
        /// <returns></returns>
        DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Recording user against deleted entity. 
        /// </summary>
        /// <returns></returns>
        string DeletedBy { get; set; }

        /// <summary>
        /// Recording user agent against deleted entity. 
        /// </summary>
        /// <returns></returns>
        //string _DeletedAgent { get; set; }
    }

}
