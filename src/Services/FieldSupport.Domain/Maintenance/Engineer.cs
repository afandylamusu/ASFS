﻿using Astra.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSupport.Domain.Maintenance
{
    public class Engineer : BaseEntity
    {
        public EngineerAvailStatus AvailStatus { get; set; }
    }
}
