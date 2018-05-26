using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astra.MobileFS.WebAdmin.Models.Dtos
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}