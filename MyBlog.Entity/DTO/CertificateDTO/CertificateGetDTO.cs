using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.CertificateDTO
{
	public class CertificateGetDTO
	{
		public int Id { get; set; }
		public string CertificateName { get; set; }
		public string Photo { get; set; }
		public string CertificateCode { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Corporation { get; set; }
    }
}
