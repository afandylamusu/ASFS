using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astra.MobileFS.WebAdmin.Models.Dtos
{
    public class FeedbackDto
    {
        public string ApplicationName { get; set; }
        public int Id { get; set; }
        public int ApplicationId { get; internal set; }
        public string Description { get; internal set; }
        public string FeedbackName { get; internal set; }
    }
}