using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astra.Core.Interfaces
{
    public interface ISearchContext
    {
        [JsonProperty(PropertyName = "$filter")]
        string Filter { get; set; }

        [JsonProperty(PropertyName = "$top")]
        int? Top { get; set; }

        [JsonProperty(PropertyName = "$skip")]
        int? Skip { get; set; }

    }

    public class SearchContext : ISearchContext
    {
        public SearchContext()
        {
            Top = 25;
            Skip = 0;
        }

        public string Filter { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
    }
}
