using FluentValidation;
using MyBlog.Entity.DTO.CertificateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	public class CertificateValidator : AbstractValidator<CertificateCrudDTO>
	{
		public CertificateValidator()
		{
			RuleFor(x => x.CertificateName).MinimumLength(25).WithMessage("Sertifika adı 25 karakterden büyük olmalıdır.");
			RuleFor(x => x.CertificateCode).NotEmpty().WithMessage("Sertifika kodu boş olamaz.");
			RuleFor(x => x.Photo).NotEmpty().WithMessage("Resim boş olamaz.");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
			RuleFor(x => x.DateOfIssue).NotEmpty().WithMessage("Tarih boş olamaz.");
			RuleFor(x => x.Corporation).NotEmpty().WithMessage("Kurum Adı boş olamaz.");
		}
	}
}
