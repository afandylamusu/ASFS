using Astra.Facades;
using FluentValidation;
using FluentValidation.Attributes;
using SubmitProblem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public interface IRetrieveInboxHeaderCommand
    {
        CommandResult<RetrieveInboxHeaderResult> Execute(RetrieveInboxHeaderArg args);
    }

    public class RetrieveInboxHeaderResult
    {
        public class MenuItem
        {
            public string Text { get; set; }
            public int Sequence { get; set; }
        }

        public class InboxHeader
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

        public List<MenuItem> MenuItems { get; set; }
        public List<InboxHeader> InboxHeaders { get; set; }

    }

    [Validator(typeof(RetrieveInboxHeaderArgValidator))]
    public class RetrieveInboxHeaderArg
    {
        /// <summary>
        /// User email
        /// </summary>
        public string UserName { get; set; }
    }

    public class RetrieveInboxHeaderCommand : IRetrieveInboxHeaderCommand
    {
        private readonly IUnitOfWork<SubmitProblemContext> _context;

        public RetrieveInboxHeaderCommand(IUnitOfWork<SubmitProblemContext> context)
        {
            _context = context;
        }

        public CommandResult<RetrieveInboxHeaderResult> Execute(RetrieveInboxHeaderArg args)
        {
            return new CommandResult<RetrieveInboxHeaderResult>(new RetrieveInboxHeaderResult());
        }
    }

    public class RetrieveInboxHeaderArgValidator : AbstractValidator<RetrieveInboxHeaderArg>
    {
        public RetrieveInboxHeaderArgValidator()
        {
            RuleFor(p => p.UserName).NotNull().NotEmpty().MinimumLength(3).NotEqual("string");
        }
    }
}
