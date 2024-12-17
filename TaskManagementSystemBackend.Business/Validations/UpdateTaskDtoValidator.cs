using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;

namespace TaskManagementSystemBackend.Business.Validations
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateOrganizationProjectTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Görev başlığı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Görev başlığı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Görev açıklaması boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Görev açıklaması en fazla 500 karakter olmalıdır.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Geçerli bir görev durumu seçilmelidir.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now).When(x => x.DueDate.HasValue).WithMessage("Bitiş tarihi gelecekte olmalıdır.");
        }
    }
}
