using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class LoginCommand : ILoginCommand
    {
        public CommandResult<LoginResult> Execute(LoginArg args)
        {
            return new CommandResult<LoginResult>(new LoginResult());
        }
    }

    public interface ILoginCommand
    {
        CommandResult<LoginResult> Execute(LoginArg args);
    }

    [Validator(typeof(LoginArgValidator))]
    public class LoginArg
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public string AccessToken { get; set; }
    }

    public class LoginArgValidator : AbstractValidator<LoginArg>
    {
        public LoginArgValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().NotEqual("string").MinimumLength(3);
            RuleFor(p => p.Password).NotEmpty().NotEqual("string").MinimumLength(3);

        }
    }
}
