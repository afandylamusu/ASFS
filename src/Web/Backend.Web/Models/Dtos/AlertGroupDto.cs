using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Web.Models.Dtos
{
    public class UserGroupAlertDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserCount { get; set; }

        public IList<User> Users { get; set; }

        public class User
        {
            public string UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}