using FluentValidation;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olmalıdır.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Bitiş tarihi şu anki tarihten sonra olmalıdır.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Geçerli bir durum seçilmelidir.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Geçerli bir kullanıcı ID'si girilmelidir.");
        }
    }
}
