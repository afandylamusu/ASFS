using FluentValidation;
using FluentValidation.Attributes;

namespace Backend.Web.Models.Forms
{
    [Validator(typeof(UserGroupAlsertFormValidator))]
    public class UserGroupAlsertForm
    {
    }

    public class UserGroupAlsertFormValidator : AbstractValidator<UserGroupAlsertForm>
    {

    }
}