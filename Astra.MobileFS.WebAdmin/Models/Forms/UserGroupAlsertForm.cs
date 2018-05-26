using FluentValidation;
using FluentValidation.Attributes;

namespace Astra.MobileFS.WebAdmin.Models.Forms
{
    [Validator(typeof(UserGroupAlsertFormValidator))]
    public class UserGroupAlsertForm
    {
    }

    public class UserGroupAlsertFormValidator : AbstractValidator<UserGroupAlsertForm>
    {

    }
}