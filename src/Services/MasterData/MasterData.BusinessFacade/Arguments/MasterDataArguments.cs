using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class Master
    {
        public string Name { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public class MasterDataArguments
    {
        public IList<Master> Masters { get; set; }
    }
}
