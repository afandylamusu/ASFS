using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Web.Models.Dtos
{
    public class ProfileDto
    {
        public string Name { get; internal set; }
        public int Id { get; internal set; }
        public string EmailAddress { get; internal set; }
    }
}