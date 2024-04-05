using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entity
{
    public class Work:BaseEntity
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }
        public bool CurrentlyJob { get; set; } = false;
    }
}
