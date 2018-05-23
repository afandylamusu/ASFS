using Backend.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Facades
{
    public interface IProfileFacade
    {
        IQueryable<ProfileDto> GetUsers(ODataQueryOptions options, bool isFs, out long count);
    }

    public class ProfileFacade : IProfileFacade
    {
        private readonly Random _intRamdom;

        public ProfileFacade()
        {
            _intRamdom = new Random();

        }

        public IQueryable<ProfileDto> GetUsers(ODataQueryOptions options, bool isFs, out long count)
        {
            var data = new List<ProfileDto>();

            for (int i = 0; i < 100; i++)
                data.Add(GenProfile());

            return data.AsQueryable().ApplyOData(options, out count);
        }

        private ProfileDto GenProfile()
        {
            int id = _intRamdom.Next(1, 100000);
            var name = Util.GenUniqueKey(15);

            return new ProfileDto
            {
                Id = id,
                Name = name,
                EmailAddress = name + "@ai.astra.co.id"
            };
        }
    }

    
}