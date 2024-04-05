using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Result;

namespace MyBlog.UI.Models
{
    public class PortfolioCertificateModel
    {
        public UIResponse<IEnumerable<PortfolioGetDTO>> Portfolio { get; set; }
        public UIResponse<IEnumerable<CertificateGetDTO>> Certificate { get; set; }
    }
}
