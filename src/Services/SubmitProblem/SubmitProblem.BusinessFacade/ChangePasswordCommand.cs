using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class ChangePasswordCommand : IChangePasswordCommand
    {
        public CommandResult<ChangePasswordResult> Execute(ChangePasswordArg args)
        {
            return new CommandResult<ChangePasswordResult>(new ChangePasswordResult());
        }
    }

    public interface IChangePasswordCommand
    {
        CommandResult<ChangePasswordResult> Execute(ChangePasswordArg args);
    }

    public class ChangePasswordResult
    {
        public DateTime LastUpdate { get; set; }
    }

    [Validator(typeof(ChangePasswordArgValidator))]
    public class ChangePasswordArg
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordArgValidator : AbstractValidator<ChangePasswordArg>
    {
        public ChangePasswordArgValidator()
        {

        }
    }
}
