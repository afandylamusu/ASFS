using FluentValidation;
using FluentValidation.Attributes;
using System.Collections.Generic;

namespace Astra.Facades
{
    public interface IGetInboxDetailCommand
    {
        CommandResult<GetInboxDetailResult> Execute(GetInboxDetailArg args);

    }

    [Validator(typeof(GetInboxDetailArgValidator))]
    public class GetInboxDetailArg
    {
        public string TicketNumber { get; set; }
        public string RequestType { get; set; }
        public string UserID { get; set; }
    }

    public class GetInboxDetailResult
    {
        public class Attachment
        {
            public string URL { get; set; }
        }

        public string TicketNumber { get; set; }
        public string Group { get; set; }
        public string Area { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string NotesHistory { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string RequesterFullName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhoneNumber { get; set; }
        public string ProblemLocation { get; set; }
        public string ActualAddress { get; set; }
    }

    public class GetInboxDetailCommand : IGetInboxDetailCommand
    {
        public CommandResult<GetInboxDetailResult> Execute(GetInboxDetailArg args)
        {
            return new CommandResult<GetInboxDetailResult>(new GetInboxDetailResult());
        }
    }

    public class GetInboxDetailArgValidator : AbstractValidator<GetInboxDetailArg>
    {
        public GetInboxDetailArgValidator()
        {

        }
    }
}
