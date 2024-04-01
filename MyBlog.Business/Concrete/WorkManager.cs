using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
    public class WorkManager : GenericManager<WorkCrudDTO, WorkGetDTO, Work>, IWorkService

    {
        public WorkManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
        {
        }
    }
}
