using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Controllers;
using Newtonsoft.Json.Linq;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : BaseController
    {
        private readonly string url = "https://localhost:7200/";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AboutController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("/Admin/About")]
        public async Task<IActionResult> About(AboutCrudDTO p)
        {

            UIResponse<AboutGetDTO> data = await GetAsync<AboutGetDTO>(url + "About/GetOne/1");
            return View(data);

        }


        [HttpPost("/UpdateAbout")]
        public async Task<JsonResult> UpdateAbout(AboutCrudDTO p, IFormFile ImageFile)
        {
            p.Id = 1;
            if (ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                if (p.Id != 0)
                {
                    // Eski dosyayı silmek için dosya yolu oluştur
                    var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", p.Photo);
                    // Dosyanın var olup olmadığını kontrol et
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        // Eğer varsa, sil
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                p.Photo = uniqueFileName;
                var data = await CrudAsync(p, url + "About/AddOrUpdate");

                if (data != null)
                {
                    HttpContext.Session.SetString("NameSurname", p.NameSurname);
                    HttpContext.Session.SetString("Photo", p.Photo);
                    return Json(new { success = true, responseText = "Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = "Hakkımda bilgileri güncellenemedi" });

            }
            else
            {
                var data = await CrudAsync(p, url + "About/AddOrUpdate");
                if (data.Success == true)
                {
                    HttpContext.Session.SetString("NameSurname", p.NameSurname);
                    HttpContext.Session.SetString("Photo", p.Photo);
                    return Json(new { success = true, responseText = " Hakkımda bilgileri güncellenmiştir" });
                }
                return Json(new { success = false, responseText = " Hakkımda bilgileri güncellenemedi" });

            }
        }
    }
}
