using Astra.Facades;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class RequestSubmitProblemCommand : IRequestSubmitProblemCommand
    {
        public CommandResult<RequestSubmitProblemResult> Execute(RequestSubmitProblemArg args)
        {
            return new CommandResult<RequestSubmitProblemResult>(new RequestSubmitProblemResult());
        }
    }

    public interface IRequestSubmitProblemCommand
    {
        CommandResult<RequestSubmitProblemResult> Execute(RequestSubmitProblemArg args);
    }

    public class RequestSubmitProblemResult
    {
        public string TicketNumber { get; set; }
    }

    [Validator(typeof(RequestSubmitProblemArgValidator))]
    public class RequestSubmitProblemArg
    {
        public class LocationArg
        {
            public string Long { get; set; }
            public string Lat { get; set; }
            public string ActualAddress { get; set; }
        }

        public class OnBehalfArg
        {
            public bool Status { get; set; }
            public string RequesterFullName { get; set; }
            public string RequesterEmail { get; set; }
            public string RequesterPhoneNumber { get; set; }
        }

        public string UserName { get; set; }
        public string Group { get; set; }
        public string Area { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public LocationArg Location { get; set; }
        public OnBehalfArg OnBehalf { get; set; }

    }

    public class RequestSubmitProblemArgValidator : AbstractValidator<RequestSubmitProblemArg>
    {
        public RequestSubmitProblemArgValidator()
        {

        }
    }
}
