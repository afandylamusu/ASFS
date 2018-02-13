using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra
{
    public interface ISearchContext
    {
        int? Top { get; set; }
        int? Skip { get; set; }
    }

    public class SearchContext : ISearchContext
    {
        public SearchContext()
        {
            Top = 25;
            Skip = 0;
        }

        //public string Filter { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
    }
}
