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

        public RetrieveMasterDataCommand(IUnitOfWork<MasterDataContext> context)
        {
            _context = context;

            _rootCauseRepo = _context.GetRepository<RootCause>();
            _rootCauseDetailRepo = _context.GetRepository<RootCauseDetail>();
            _rootCauseGroupRepo = _context.GetRepository<RootCauseGroup>();
        }

        public CommandResult<RetrieveMasterDataResult> Execute(MasterDataArguments args)
        {
            var data = new RetrieveMasterDataResult();

            data.RootCauseAreas = _rootCauseRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.RootCauseDetails = _rootCauseDetailRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();
            data.RootCauseGroups = _rootCauseGroupRepo.Queryable.Where(o => o.RowStatus == RowStatus.ACTIVE).ToList();

            var result = new CommandResult<RetrieveMasterDataResult>(data);

            return result;
        }

    }
}
