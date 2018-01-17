using System;
using System.Collections.Generic;
using System.Text;

namespace Astra.Core.Interfaces
{
    public interface ISearchContext
    {
        int? Size { get; set; }
        int? Index { get; set; }
    }
}
