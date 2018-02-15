using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;

namespace Astra.Facades
{
    public class RequestHistoryCommand : IRequestHistoryCommand
    {
        public CommandResult<RequestHistoryResult> Execute(RequestHistoryArg args)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRequestHistoryCommand
    {
        CommandResult<RequestHistoryResult> Execute(RequestHistoryArg args);
    }

    [Validator(typeof(RequestHistoryArgValidator))]
    public class RequestHistoryArg
    {
        public string UserName { get; set; }
    }

    public class RequestHistoryResult
    {
        public class InboxHeaderResult
        {
            public string UserID { get; set; }
            public string UserFullName { get; set; }
            public string RequestType { get; set; }
            public string RequesterFullName { get; set; }
            public string TicketNumber { get; set; }
            public DateTime DocumentDate { get; set; }
            public DateTime LastUpdate { get; set; }
            public int DestinationID { get; set; }
            public int ProcessID { get; set; }
            public string StatusName { get; set; }
            public int TaskID { get; set; }
            public string SLACode { get; set; }
            public string SLADuration { get; set; }
        }

        public List<InboxHeaderResult> InboxHeaders { get; set; }
    }

    public class RequestHistoryArgValidator : AbstractValidator<RequestHistoryArg>
    {
        public RequestHistoryArgValidator()
        {

        }
    }
}
