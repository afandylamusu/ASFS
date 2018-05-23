using Backend.Web.Models;
using Backend.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Facades
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAlertFacade
    {
        IQueryable<NewsDto> Find(ODataQueryOptions options, out long count);
        IQueryable<RecipientDto> GetRecipients(ODataQueryOptions options, out long count);
    }

    /// <summary>
    /// 
    /// </summary>
    public class AlertFacade : IAlertFacade
    {
        private readonly HttpContextBase _HttpContext;
        private readonly Random _intRamdom;

        public AlertFacade(HttpContextBase httpContext )
        {
            _HttpContext = httpContext;
            _intRamdom = new Random();
        }

        public IQueryable<NewsDto> Find(ODataQueryOptions options, out long count)
        {
            var data = new List<NewsDto>();

            for (int i = 0; i < 100; i++)
                data.Add(NewsDummy());

            return data.AsQueryable().ApplyOData(options, out count);
        }

        public IQueryable<RecipientDto> GetRecipients(ODataQueryOptions options, out long count)
        {
            var data = new List<RecipientDto>();

            for (int i = 0; i < 50; i++)
            {
                int id = _intRamdom.Next(1, 100000);

                data.Add(new RecipientDto { Id = id + 1, Alias = "Sample Recipient " + (id + 1), Type = (id % 5) == 0 ? "GROUP" : "INDIVIDUAL" });
            }

            return data.AsQueryable().ApplyOData(options, out count);
        }

        private NewsDto NewsDummy()
        {
            int id = _intRamdom.Next(1, 100000);
            return new NewsDto
            {
                Id = id,
                Title = "Sample " + id,
                StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                EndDate = DateTime.Now,
                Content = "Sample content",
                Recepients = new RecipientDto[]{
                    new RecipientDto { Id = id+1, Alias ="sample "+(id+1), Type = (id % 5) == 0 ? "GROUP" : "INDIVIDUAL" }
                }
            };
        }
    }
}