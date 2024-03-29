using FluentValidation;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.EducationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
    public class EducationValidator : AbstractValidator<EducationCrudDTO>
    {
        public EducationValidator()
        {
            RuleFor(x => x.Description).MaximumLength(4).WithMessage("Kullanıcı adı 4 karakterden büyük olmalıdır.");
            RuleFor(x => x.Description).MinimumLength(1).WithMessage("Kullanıcı adı 4 karakterden büyük olmalıdır.");
            RuleFor(x => x.StartingDate).NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");
            RuleFor(x => x.EndingDate).NotEmpty().WithMessage("Bitiş tarihi boş olamaz.");
            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Meslek boş olamaz.");
            RuleFor(x => x.Degree).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
            RuleFor(x => x.Faculty).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
            RuleFor(x => x.Section).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
        }
    }
}
