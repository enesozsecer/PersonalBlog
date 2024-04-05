using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.CertificateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
	public interface ICertificateService : IGenericService<CertificateCrudDTO, CertificateGetDTO>
	{
	}
}
