using Backend.Web.Models.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Facades
{

    public interface IMasterFacade
    {
        IQueryable<ApplicationDto> GetApplications(ODataQueryOptions options, out long count);
    }

    public class MasterFacade : IMasterFacade
    {
        public IQueryable<ApplicationDto> GetApplications(ODataQueryOptions options, out long count)
        {
            var data = new List<ApplicationDto>();

            for (int i = 0; i < 10; i++)
                data.Add(new ApplicationDto { Id = i+1, Name = "App " + i });

            return data.AsQueryable().ApplyOData(options, out count);
        }
    }
}