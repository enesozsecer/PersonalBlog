using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.Result;

namespace MyBlog.API.Controllers
{
    [Route("[controller]/[action]")]

    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _service;

        public EducationController(IEducationService service)
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
        //	var deneme=new EducationGetDTO();
        //	deneme.Id = id;
        //	var value = await _service.GetAsync(id,x=>true);
        //	return Ok(value);
        //}

        [HttpPost("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var deneme = new EducationGetDTO();
            deneme.Id = id;
            var value = await _service.GetAsync(id, x => true);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(EducationCrudDTO Education)
        {
            ApiResponse<EducationGetDTO> value;
            if (Education.Id == 0)
            {
                value = await _service.AddAsync(Education);
                return Ok(value);
            }
            value = await _service.UpdateAsync(Education);
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
