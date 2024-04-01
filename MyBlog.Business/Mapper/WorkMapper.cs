using AutoMapper;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Mapper
{
    internal class WorkMapper : Profile
    {
        public WorkMapper()
        {
            CreateMap<Work, WorkGetDTO>();
            CreateMap<WorkCrudDTO, Work>();

            CreateMap<Work, WorkCrudDTO>().ReverseMap();
        }
    }
}
