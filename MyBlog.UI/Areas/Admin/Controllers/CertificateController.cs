using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using System.Security.Policy;

namespace MyBlog.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CertificateController : BaseController
	{
		private readonly string url = "https://localhost:7200/";
		private readonly IWebHostEnvironment _hostingEnvironment;

		public CertificateController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		[HttpGet("/Admin/Certificate")]
		public async Task<IActionResult> Certificate()
		{
			UIResponse<IEnumerable<CertificateGetDTO>> data = await GetAllAsync<CertificateGetDTO>(url + "Certificate/GetAll");
			return View(data);
		}
		[HttpPost("/CrudCertificate")]
		public async Task<IActionResult> CrudCertificate(CertificateCrudDTO p, IFormFile FormFile)
		{
			if (FormFile != null)
			{
				var uniqueFileName = Guid.NewGuid().ToString() + "_" + FormFile.FileName;
				var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await FormFile.CopyToAsync(stream);
                }
				if (p.Id != 0)
				{
                    var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", p.Photo);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                p.Photo = uniqueFileName;
                var data = await CrudAsync(p, url + "Certificate/AddOrUpdate");

				if (data != null)
				{
					return Json(new { success = true, responseText = " İşlem Başarılı" });
				}
				return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
			}
			else
			{
				var data = await CrudAsync(p, url + "Certificate/AddOrUpdate");
				if (data.Success == true)
				{
					return Json(new { success = true, responseText = " İşlem Başarılı" });
				}
				return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

			}
		}
		[HttpPost("/DeleteCertificate")]
		public async Task<IActionResult> DeleteCertificate(int id)
		{
			var data = await DeleteAsync(url + "Certificate/Remove/" + id);
			if (data)
			{
				return Json(new { success = true, responseText = " İşlem Başarılı" });
			}
			return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

		}
	}
}
