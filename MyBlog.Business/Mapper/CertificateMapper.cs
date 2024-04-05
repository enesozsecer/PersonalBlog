using AutoMapper;
using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
	public class CertificateMapper : Profile
	{
		public CertificateMapper()
		{
			CreateMap<Certificate, CertificateGetDTO>();
			CreateMap<CertificateCrudDTO, Certificate>();

			CreateMap<Certificate, CertificateCrudDTO>().ReverseMap();
		}
	}
}
