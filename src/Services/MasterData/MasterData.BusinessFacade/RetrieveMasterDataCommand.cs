using MasterData.Data;
using MasterData.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class RetrieveMasterDataArg
    {

        public class Master
        {
            public string Name { get; set; }
            public DateTime? LastModified { get; set; }
        }

        public IList<Master> Masters { get; set; }
    }

    public class RetrieveMasterDataResult
    {

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

    public interface IRetrieveMasterDataCommand
    {
        CommandResult<RetrieveMasterDataResult> Execute(RetrieveMasterDataArg args);
    }


    public class RetrieveMasterDataCommand : IRetrieveMasterDataCommand
    {
        private readonly IUnitOfWork<MasterDataContext> _context;
        private readonly IRepository<RootCause> _rootCauseRepo;
        private readonly IRepository<RootCauseDetail> _rootCauseDetailRepo;
        private readonly IRepository<RootCauseGroup> _rootCauseGroupRepo;
        private readonly IRepository<IncidentArea> _incidentAreaRepo;
        private readonly IRepository<IncidentAreaGroup> _incidentAreaGroupRepo;
        private readonly IRepository<IncidentAreaDetail> _incidentAreaDetailRepo;

        public RetrieveMasterDataCommand(IUnitOfWork<MasterDataContext> context)
        {
            _context = context;

            _rootCauseRepo = _context.GetRepository<RootCause>();
            _rootCauseDetailRepo = _context.GetRepository<RootCauseDetail>();
            _rootCauseGroupRepo = _context.GetRepository<RootCauseGroup>();
            _incidentAreaRepo = _context.GetRepository<IncidentArea>();
            _incidentAreaGroupRepo = _context.GetRepository<IncidentAreaGroup>();
            _incidentAreaDetailRepo = _context.GetRepository<IncidentAreaDetail>();
        }

        public CommandResult<RetrieveMasterDataResult> Execute(RetrieveMasterDataArg args)
        {
            var data = new RetrieveMasterDataResult();

            RetrieveMasterDataArg.Master temp = null;

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "RootCauseAreas")) != null)
                data.RootCauseAreas = _rootCauseRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "RootCauseDetails")) != null)
                data.RootCauseDetails = _rootCauseDetailRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "RootCauseGroups")) != null)
                data.RootCauseGroups = _rootCauseGroupRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "ProblemAreas")) != null)
                data.ProblemAreas = _incidentAreaRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "ProblemDetails")) != null)
                data.ProblemDetails = _incidentAreaDetailRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();

            if ((temp = args.Masters.FirstOrDefault(o => o.Name == "ProblemGroups")) != null)
                data.ProblemGroups = _incidentAreaGroupRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE && o.ModifiedOn > temp.LastModified).ToList();



            var result = new CommandResult<RetrieveMasterDataResult>(data);

            return result;
        }

    }
}
