using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.DataManagement;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Concrete
{
	public class CertificateRepository : Repository<Certificate>, ICertificateRepository
	{
		public CertificateRepository(DbContext context) : base(context)
		{
		}
	}
}
