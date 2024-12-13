using FluentValidation;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class CreateOrganizationDtoValidator : AbstractValidator<CreateOrganizationDto>
    {
        public CreateOrganizationDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Organizasyon adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Organizasyon adı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Organizasyon açıklaması boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Organizasyon açıklaması en fazla 500 karakter olmalıdır.");
        }
    }
}
