using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Backend.Web.Models.Forms;

namespace Backend.Web.Facades
{
    public interface IFeedbackFacade
    {
        Task<bool> CreateFeedback(FeedbackForm form);
    }

    public class FeedbackFacade : IFeedbackFacade
    {
        public async Task<bool> CreateFeedback(FeedbackForm form)
        {
            return await Task.FromResult(true);
        }
    }
}