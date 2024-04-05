using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.DTO.AboutDTO
{
	public class AboutGetDTO
	{
		public int Id { get; set; }
		public string NameSurname { get; set; }
		public DateTime BirthDate { get; set; }
		public string Job { get; set; }
		public string Mail { get; set; }
		public string Resume { get; set; }
		public string Photo { get; set; }
        public string Intro { get; set; }
        public string PhoneNumber { get; set; }
        public string MilitarySituation { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string DriverLicence { get; set; }
        public string Travelability { get; set; }
        public string MaritalStatus { get; set; }
    }
}
