using AutoMapper;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
    public class EducationMapper : Profile
    {
        public EducationMapper()
        {
            CreateMap<Education, EducationGetDTO>();
            CreateMap<EducationCrudDTO, Education>();

            CreateMap<Education, EducationCrudDTO>().ReverseMap();
        }
    }
}
