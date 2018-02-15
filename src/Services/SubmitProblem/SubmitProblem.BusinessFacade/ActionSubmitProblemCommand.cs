using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{

    public class ActionSubmitProblemCommand : IActionSubmitProblemCommand
    {
        public CommandResult<ActionSubmitProblemResult> Execute(ActionSubmitProblemArg args)
        {
            return new CommandResult<ActionSubmitProblemResult>(new ActionSubmitProblemResult());
        }
    }

    public interface IActionSubmitProblemCommand
    {
        CommandResult<ActionSubmitProblemResult> Execute(ActionSubmitProblemArg args);
    }

    public class ActionSubmitProblemResult
    {
        public string TicketNumber { get; set; }
    }

    [Validator(typeof(ActionSubmitProblemArgValidator))]
    public class ActionSubmitProblemArg
    {
        public class RootCauseArg
        {
            public string Group { get; set; }
            public string Area { get; set; }
            public string Detail { get; set; }
        }

        public string TicketNumber { get; set; }
        public string UserName { get; set; }
        public string AssignmentStatus { get; set; }
        public RootCauseArg RootCause { get; set; }
        public string AssigneeUserName { get; set; }
        public string Description { get; set; }
    }

    public class ActionSubmitProblemArgValidator : AbstractValidator<ActionSubmitProblemArg>
    {
        public ActionSubmitProblemArgValidator()
        {

        }
    }

}
