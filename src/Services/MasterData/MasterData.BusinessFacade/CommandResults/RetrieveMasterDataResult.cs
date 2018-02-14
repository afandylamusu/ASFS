using MasterData.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astra.Facades
{
    

    public class RetrieveMasterDataResult {

        public RetrieveMasterDataResult()
        {
            Menus = new List<object>();
            UserCategories = new List<object>();
            ProblemAreas = new List<IncidentArea>();
            ProblemDetails = new List<IncidentAreaDetail>();
            ProblemGroups = new List<IncidentAreaGroup>();
            RootCauseGroups = new List<RootCauseGroup>();
            RootCauseAreas = new List<RootCause>();
            RootCauseDetails = new List<RootCauseDetail>();
            FSProfiles = new List<object>();
            AdditionalRatings = new List<object>();
        }

        public IList<object> Menus { get; internal set; }
        public IList<object> UserCategories { get; internal set; }
        public IList<IncidentAreaGroup> ProblemGroups { get; internal set; }
        public IList<IncidentArea> ProblemAreas { get; internal set; }
        public IList<IncidentAreaDetail> ProblemDetails { get; internal set; }
        public IList<RootCauseGroup> RootCauseGroups { get; internal set; }
        public IList<RootCause> RootCauseAreas { get; internal set; }
        public IList<RootCauseDetail> RootCauseDetails { get; internal set; }
        public IList<object> FSProfiles { get; internal set; }
        public IList<object> AdditionalRatings { get; internal set; }
    }
}
