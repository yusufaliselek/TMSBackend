using FluentValidation;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class UpdateOrganizationDtoValidator : AbstractValidator<UpdateOrganizationDto>
    {
        public UpdateOrganizationDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Organizasyon adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Organizasyon adı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Organizasyon açıklaması boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Organizasyon açıklaması en fazla 500 karakter olmalıdır.");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("Organizasyon sahibi geçerli bir kullanıcı olmalıdır.");

            RuleFor(x => x.OwnerName)
                .NotEmpty().WithMessage("Organizasyon sahibi kullanıcı adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Organizasyon sahibi kullanıcı adı en fazla 100 karakter olmalıdır.");
        }
    }
}
