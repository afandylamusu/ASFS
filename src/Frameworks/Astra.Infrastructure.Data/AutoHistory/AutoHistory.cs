﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public class AutoHistory : BaseEntity
    {
        public AutoHistory()
        {
            this.Created = DateTime.UtcNow;
        }
        /// <summary>
        /// Gets or sets the source row id.
        /// </summary>
        /// <value>The source row id.</value>
        public string RowId { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the json about the changing.
        /// </summary>
        /// <value>The json about the changing.</value>
        public string Changed { get; set; }

        /// <summary>
        /// Gets or sets the change kind.
        /// </summary>
        /// <value>The change kind.</value>
        public EntityState Kind { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public DateTime Created { get; set; }
    }
}
