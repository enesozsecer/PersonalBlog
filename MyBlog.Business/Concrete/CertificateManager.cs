using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
	public class CertificateManager : GenericManager<CertificateCrudDTO, CertificateGetDTO, Certificate>, ICertificateService

	{
		public CertificateManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
