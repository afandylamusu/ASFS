using FluentValidation;
using FluentValidation.Attributes;

namespace Astra.MobileFS.WebAdmin.Models.Forms
{
    [Validator(typeof(FeedbackFormValidator))]
    public class FeedbackForm
    {
    }

    public class FeedbackFormValidator : AbstractValidator<FeedbackForm>
    {

    }
}