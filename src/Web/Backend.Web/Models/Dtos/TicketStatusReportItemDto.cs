using Newtonsoft.Json;
using System;

namespace Backend.Web.Models.Dtos
{
    public class TicketStatusReportItemDto
    {
        public int Id { get; set; }
        [JsonProperty("SLA")]
        public string SLA { get; set; }
        public DateTime? ExpectedTime { get; set; }
        public string TicketNo { get; set; }
        public DateTime? TicketCreatedDate { get; set; }
        public string Requester { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        [JsonProperty("PICName")]
        public string PICName { get; set; }
        public string Status { get; set; }
    }

    public class UserFeedbackReportItemDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string AdditionalFeedback { get; set; }
        public string Comment { get; set; }
        public string TicketNo { get; set; }
        public DateTime? TicketCreatedDate { get; set; }
        public string Requester { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        [JsonProperty("PICName")]
        public string PICName { get; set; }
    }
}