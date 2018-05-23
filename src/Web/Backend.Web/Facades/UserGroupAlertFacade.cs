using Backend.Web.Models.Dtos;
using Backend.Web.Models.Forms;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Facades
{
    public interface IUserGroupAlertFacade
    {
        Task<int> CreateUserGroupAsync(UserGroupAlsertForm form);
        IQueryable<UserGroupAlertDto> GetUserGroups(ODataQueryOptions options, out long count);
    }

    public class UserGroupAlertFacade : IUserGroupAlertFacade
    {
        private readonly IValidator<UserGroupAlsertForm> _validatorUserGroupAlertForm;
        private readonly Random _intRamdom;

        public UserGroupAlertFacade(IValidator<UserGroupAlsertForm> validatorUserGroupAlertForm)
        {
            _validatorUserGroupAlertForm = validatorUserGroupAlertForm;
            _intRamdom = new Random();
        }

        public async Task<int> CreateUserGroupAsync(UserGroupAlsertForm form)
        {
            if (form == null) throw new ArgumentNullException("UserGroupAlsertForm Form cannot be null");
            _validatorUserGroupAlertForm.ValidateAndThrow(form);

            //var record = new MFSUserCategory

            return 0;
        }

        public IQueryable<UserGroupAlertDto> GetUserGroups(ODataQueryOptions options, out long count)
        {
            var data = new List<UserGroupAlertDto>();

            for (int i = 0; i < 100; i++)
                data.Add(GenUserGroupAlert());

            return data.AsQueryable().ApplyOData(options, out count);
        }

        private UserGroupAlertDto GenUserGroupAlert()
        {
            int id = _intRamdom.Next();

            var result = new UserGroupAlertDto {
                Id = id,
                Name = "Group "+Util.GenUniqueKey(3),
            };

            result.Users = new List<UserGroupAlertDto.User>();

            for (int i = 0; i < 5; i++)
                result.Users.Add(new UserGroupAlertDto.User
                {
                    UserID = Util.GenUniqueKey(8),
                    Name = "Anom " + Util.GenUniqueKey(4),
                    Email = "anom" + Util.GenUniqueKey(4) + "@ai.astra.co.id"
                });

            result.UserCount = result.Users.Count;

            return result;
        }
    }
}