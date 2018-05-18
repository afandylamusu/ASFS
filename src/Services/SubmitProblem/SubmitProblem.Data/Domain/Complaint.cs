using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SubmitProblem.Data.Domain
{
    [Table("Complaints")]
    public partial class Complaint : BaseEntityHistory
    {
        public int ApplicationID { get; set; }
        public int TicketStatusID { get; set; }
        public int BusinessAreaID { get; set; }
        public int IncidentAreaDetailID { get; set; }
        public int SeverityLevelID { get; set; }
        public string TicketNumber { get; set; }
        public string TicketRefNumber { get; set; }
        public string TicketDescription { get; set; }
        public string RequestDescription { get; set; }
        public string EmailCCAddress { get; set; }
        public string Attachment { get; set; }
        public string NotesHistory { get; set; }
        public DateTime EstimatedExpectedOn { get; set; }
        public DateTime CalculatedExpectedOn { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservedOn { get; set; }
        public DateTime SolvedOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Location { get; set; }
        public bool IsFS { get; set; }

    }
}
