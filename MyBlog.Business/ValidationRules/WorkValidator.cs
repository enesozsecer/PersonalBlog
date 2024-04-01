using FluentValidation;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.WorkDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
    public class WorkValidator : AbstractValidator<WorkCrudDTO>
    {
        public WorkValidator()
        {
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("Açıklama 4 karakterden büyük olmalıdır.");
            RuleFor(x => x.StartingDate).NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");
            RuleFor(x => x.EndingDate).NotEmpty().WithMessage("Bitiş tarihi boş olamaz.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket boş olamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş olamaz.");
            RuleFor(x => x.Experience).NotEmpty().WithMessage("Deneyim boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
        }
    }
}
