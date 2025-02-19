using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Application.UseCases.Users.Register
{
    internal class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(RuleFor => RuleFor.Password).NotEmpty().WithMessage("Password is required.");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters.");
                RuleFor(request => request.Password).Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.");
                RuleFor(request => request.Password).Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.");
                RuleFor(request => request.Password).Matches("[0-9]").WithMessage("Password must contain at least one number.");
                RuleFor(request => request.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
            });
        }
    }
}
