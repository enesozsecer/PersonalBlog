using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
    public class Education : BaseEntity
    {
        public string Score { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string Faculty { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }
        public bool CurrentlyEducation { get; set; }

    }
}
