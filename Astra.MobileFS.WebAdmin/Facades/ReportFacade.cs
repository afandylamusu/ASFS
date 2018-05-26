using Astra.MobileFS.WebAdmin.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Astra.MobileFS.WebAdmin.Facades
{
    public interface IReportFacade
    {
        IQueryable<TicketStatusReportItemDto> GetTicketStatusReport(ODataQueryOptions options, out long count);
        IQueryable<UserFeedbackReportItemDto> GetUserFeedbackReport(ODataQueryOptions options, out long count);
        IEnumerable<TicketStatusReportItemDto> GetTicketStatusReport(IEnumerable<int> ids);
    }

    public class ReportFacade : IReportFacade
    {
        private readonly Random _intRamdom;

        public ReportFacade()
        {
            _intRamdom = new Random();

        }

        public IQueryable<TicketStatusReportItemDto> GetTicketStatusReport(ODataQueryOptions options, out long count)
        {
            var data = new List<TicketStatusReportItemDto>();

            for (int i = 0; i < 100; i++)
                data.Add(GenTicketStatusReportItem(i));

            return data.AsQueryable().ApplyOData(options, out count);
        }

        public IQueryable<UserFeedbackReportItemDto> GetUserFeedbackReport(ODataQueryOptions options, out long count)
        {
            var data = new List<UserFeedbackReportItemDto>();

            for (int i = 0; i < 100; i++)
                data.Add(GenUserFeedbackReportItem(i));

            return data.AsQueryable().ApplyOData(options, out count);
        }

        private UserFeedbackReportItemDto GenUserFeedbackReportItem(int i)
        {
            int id = i + 1;// _intRamdom.Next(1, 100000);

            return new UserFeedbackReportItemDto
            {
                Id = id,
                TicketNo = Util.GenTicketNumber(),
                TicketCreatedDate = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                Requester = "Admin",
                Group = "H001",
                Category = "Hardware",
                SubCategory = "Laptop & PC",
                Description = "Lapatop sering mati",
                PICName = "Mulyadi",
                AdditionalFeedback = "Sample text",
                Comment = "Comment",
                Rating = 5
            };
        }

        private TicketStatusReportItemDto GenTicketStatusReportItem(int i)
        {
            int id = i + 1;//_intRamdom.Next(1, 100000);

            return new TicketStatusReportItemDto {
                Id = id,
                SLA = "2H 42m",
                ExpectedTime = DateTime.Now,
                TicketNo = Util.GenTicketNumber(),
                TicketCreatedDate = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                Requester = "Admin",
                Group = "H001",
                Category = "Hardware",
                SubCategory = "Laptop & PC",
                Description = "Lapatop sering mati",
                PICName = "Mulyadi",
                Status = "Open"
            };
        }

        public IEnumerable<TicketStatusReportItemDto> GetTicketStatusReport(IEnumerable<int> ids)
        {
            var data = new List<TicketStatusReportItemDto>();

            for (int i = 0; i < 30; i++)
                data.Add(GenTicketStatusReportItem(i));

            return data;
        }
    }
}