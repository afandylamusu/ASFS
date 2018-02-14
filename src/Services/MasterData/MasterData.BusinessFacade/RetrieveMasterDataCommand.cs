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

        public CommandResult<RetrieveMasterDataResult> Execute(MasterDataArguments args)
        {
            var data = new RetrieveMasterDataResult();

            data.RootCauseAreas = _rootCauseRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.RootCauseDetails = _rootCauseDetailRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.RootCauseGroups = _rootCauseGroupRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();

            data.ProblemAreas = _incidentAreaRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.ProblemDetails = _incidentAreaDetailRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.ProblemGroups = _incidentAreaGroupRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();

            var result = new CommandResult<RetrieveMasterDataResult>(data);

            return result;
        }

    }
}
