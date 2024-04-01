using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using System.Security.Policy;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WorkController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WorkController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("/Admin/Work")]
        public async Task<IActionResult> Work()
        {
            UIResponse<IEnumerable<WorkGetDTO>> data = await GetAllAsync<WorkGetDTO>(url + "Work/GetAll");
            return View(data);
        }
        [HttpPost("/CrudWork")]
        public async Task<IActionResult> CrudWork(WorkCrudDTO p, IFormFile FormFile)
        {
            if (FormFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + FormFile.FileName;
                var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await FormFile.CopyToAsync(stream);
                }
                p.Photo = uniqueFileName;
                var data = await CrudAsync(p, url + "Work/AddOrUpdate");

                if (data != null)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });
            }
            else
            {
                var data = await CrudAsync(p, url + "Work/AddOrUpdate");
                if (data.Success == true)
                {
                    return Json(new { success = true, responseText = " İşlem Başarılı" });
                }
                return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

            }
        }
        [HttpPost("/DeleteWork")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var data = await DeleteAsync(url + "Work/Remove/" + id);
            if (data)
            {
                return Json(new { success = true, responseText = " İşlem Başarılı" });
            }
            return Json(new { success = false, responseText = " İşlem Başarısız Oldu!" });

        }
    }
}
