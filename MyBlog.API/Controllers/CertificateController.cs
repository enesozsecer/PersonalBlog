using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Result;

namespace MyBlog.API.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class CertificateController : ControllerBase
	{
		private readonly ICertificateService _service;

		public CertificateController(ICertificateService service)
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
		//	var deneme=new CertificateGetDTO();
		//	deneme.Id = id;
		//	var value = await _service.GetAsync(id,x=>true);
		//	return Ok(value);
		//}

		[HttpPost("{id}")]
		public async Task<IActionResult> GetOne(int id)
		{
			var deneme = new CertificateGetDTO();
			deneme.Id = id;
			var value = await _service.GetAsync(id, x => true);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(CertificateCrudDTO Certificate)
		{
			ApiResponse<CertificateGetDTO> value;
			if (Certificate.Id == 0)
			{
				value = await _service.AddAsync(Certificate);
				return Ok(value);
			}
			value = await _service.UpdateAsync(Certificate);
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
