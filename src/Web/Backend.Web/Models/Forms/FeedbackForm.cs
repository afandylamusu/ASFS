using FluentValidation;
using FluentValidation.Attributes;

namespace Backend.Web.Models.Forms
{
    [Validator(typeof(FeedbackFormValidator))]
    public class FeedbackForm
    {
    }

    public class FeedbackFormValidator : AbstractValidator<FeedbackForm>
    {

    }
}