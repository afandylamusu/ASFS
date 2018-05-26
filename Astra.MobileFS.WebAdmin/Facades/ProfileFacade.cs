using Astra.MobileFS.WebAdmin.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Astra.MobileFS.WebAdmin.Facades
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
                data.Add(GenProfile(i));

            return data.AsQueryable().ApplyOData(options, out count);
        }

        private ProfileDto GenProfile(int i)
        {
            int id = i + 1;//_intRamdom.Next(1, 100000);
            var name = Util.GenUniqueKey(15);

            return new ProfileDto
            {
                Id = id,
                Name = name,
                Email = name + "@ai.astra.co.id",
                Username = name,
                Lat = -6.230612M,
                Lng = 106.804332M,
                Phone = "081245" + Util.GenTicketNumber(6)
            };
        }
    }

    
}