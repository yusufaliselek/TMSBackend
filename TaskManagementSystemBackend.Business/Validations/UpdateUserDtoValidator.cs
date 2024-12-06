using FluentValidation;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");
        }
    }
}
