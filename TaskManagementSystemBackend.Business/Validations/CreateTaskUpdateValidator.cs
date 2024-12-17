using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class CreateTaskUpdateDtoValidator : AbstractValidator<CreateOrganizationProjectTaskUpdateDto>
    {
        public CreateTaskUpdateDtoValidator()
        {
            RuleFor(x => x.TaskId)
                .GreaterThan(0).WithMessage("Geçerli bir görev ID'si girilmelidir.");

            RuleFor(x => x.OldStatus)
                .IsInEnum().WithMessage("Geçerli bir eski durum seçilmelidir.");

            RuleFor(x => x.NewStatus)
                .IsInEnum().WithMessage("Geçerli bir yeni durum seçilmelidir.")
                .NotEqual(x => x.OldStatus).WithMessage("Yeni durum eski durumdan farklı olmalıdır.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olmalıdır.");
        }
    }
}
