using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Astra.MobileFS.WebAdmin.Models.Dtos;
using Astra.MobileFS.WebAdmin.Models.Forms;

namespace Astra.MobileFS.WebAdmin.Facades
{
    public interface IFeedbackFacade
    {
        Task<bool> CreateFeedbackAsync(FeedbackForm form);
        IQueryable<FeedbackDto> GetFeedbacks(ODataQueryOptions options, out long count);
    }

    public class FeedbackFacade : IFeedbackFacade
    {
        private readonly Random _intRamdom;

        public FeedbackFacade()
        {
            _intRamdom = new Random();
        }

        public async Task<bool> CreateFeedbackAsync(FeedbackForm form)
        {
            return await Task.FromResult(true);
        }

        public IQueryable<FeedbackDto> GetFeedbacks(ODataQueryOptions options, out long count)
        {
            var data = new List<FeedbackDto>();

            for (int i = 0; i < 100; i++)
                data.Add(new FeedbackDto { Id = i+1, ApplicationName = "App " + i, ApplicationId = i + 1, FeedbackName = "Feedback " + Util.GenUniqueKey(3), Description = "Description " + Util.GenUniqueKey(10) });

            return data.AsQueryable().ApplyOData(options, out count);
        }
    }
}