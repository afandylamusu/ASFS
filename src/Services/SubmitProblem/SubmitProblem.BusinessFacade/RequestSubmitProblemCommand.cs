using FluentValidation;
using FluentValidation.Attributes;

namespace Astra.Facades
{
    public class RequestSubmitProblemResult
    {
        public string TicketNumber { get; set; }
    }

    [Validator(typeof(RequestSubmitProblemArgValidator))]
    public class RequestSubmitProblemArg
    {
        public class LocationArg
        {
            public decimal? Long { get; set; }
            public decimal? Lat { get; set; }
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
            RuleFor(p => p.UserName).NotNull().NotEmpty();
            RuleFor(p => p.Group).NotNull().NotEmpty();
            RuleFor(p => p.Area).NotNull().NotEmpty();
            RuleFor(p => p.Detail).NotNull().NotEmpty();
            RuleFor(p => p.Description).NotNull().NotEmpty();

            RuleFor(p => p.Location.ActualAddress).NotNull().NotEmpty();

            When(p => p.OnBehalf != null, () => {
                RuleFor(p => p.OnBehalf.RequesterEmail).NotNull().NotEmpty();
                RuleFor(p => p.OnBehalf.RequesterFullName).NotNull().NotEmpty();
                RuleFor(p => p.OnBehalf.RequesterPhoneNumber).NotNull().NotEmpty();
            });
        }
    }

    public interface IRequestSubmitProblemCommand
    {
        CommandResult<RequestSubmitProblemResult> Execute(RequestSubmitProblemArg args);
    }

    public class RequestSubmitProblemCommand : IRequestSubmitProblemCommand
    {
        public CommandResult<RequestSubmitProblemResult> Execute(RequestSubmitProblemArg args)
        {


            return new CommandResult<RequestSubmitProblemResult>(new RequestSubmitProblemResult());
        }
    }

    


}
