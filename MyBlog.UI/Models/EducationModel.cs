using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Result;

namespace MyBlog.UI.Models
{
    public class EducationModel
    {
        public UIResponse<EducationGetDTO> Education { get; set; }
        //public UIResponse<IEnumerable<SkillsGetDTO>> Skills { get; set; }
    }
}
