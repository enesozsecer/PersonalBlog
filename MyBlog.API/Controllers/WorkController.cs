using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Result;
namespace MyBlog.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _service;
        public WorkController(IWorkService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> GetAll()
        {
            var value = await _service.GetAllAsync();
            return Ok(value);
        }
        //[HttpPost("{id}")]
        //public async Task<IActionResult> GetOne(int id)
        //{
        //	var deneme=new WorkGetDTO();
        //	deneme.Id = id;
        //	var value = await _service.GetAsync(id,x=>true);
        //	return Ok(value);
        //}
        [HttpPost("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var deneme = new WorkGetDTO();
            deneme.Id = id;
            var value = await _service.GetAsync(id, x => true);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(WorkCrudDTO Work)
        {
            ApiResponse<WorkGetDTO> value;
            if (Work.Id == 0)
            {
                value = await _service.AddAsync(Work);
                return Ok(value);
            }
            value = await _service.UpdateAsync(Work);
            return Ok(value);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var value = await _service.RemoveAsync(id);
            return Ok(value);
        }
    }
}
