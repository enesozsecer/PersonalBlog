using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Result;

namespace MyBlog.UI.Models
{
    public class EducationWorkModel
    {
        public UIResponse<IEnumerable<EducationGetDTO>> Education { get; set; }
        public UIResponse<IEnumerable<WorkGetDTO>> Work { get; set; }
        //public UIResponse<IEnumerable<WorkGetDTO>> Skills { get; set; }
    }
}
