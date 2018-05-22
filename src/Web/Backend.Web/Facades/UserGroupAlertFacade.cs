using Backend.Web.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Backend.Web.Facades
{
    public interface IUserGroupAlertFacade
    {
        Task<bool> CreateUserGroup(UserGroupAlsertForm form);
    }

    public class UserGroupAlertFacade : IUserGroupAlertFacade
    {
        public Task<bool> CreateUserGroup(UserGroupAlsertForm form)
        {
            throw new NotImplementedException();
        }
    }
}