using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.WorkDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface IWorkService : IGenericService<WorkCrudDTO, WorkGetDTO>
    {
    }
}
