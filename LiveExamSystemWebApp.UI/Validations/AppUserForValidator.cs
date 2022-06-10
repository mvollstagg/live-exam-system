using FluentValidation;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.UI.Validations;

public class AppUserForValidator : AbstractValidator<AppUser>
{
    public AppUserForValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Gerekli alan, lütfen doldurunuz.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Gerekli alan, lütfen doldurunuz.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Gerekli alan, lütfen doldurunuz.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Gerekli alan, lütfen doldurunuz.");
        RuleFor(x => x.PasswordAgain).NotEmpty().WithMessage("Gerekli alan, lütfen doldurunuz.");
        RuleFor(x => x.PasswordAgain).Equal(x => x.Password).WithMessage("Girdiğiniz şifrenin aynı olduğundan emin olunuz.");
    }
}

