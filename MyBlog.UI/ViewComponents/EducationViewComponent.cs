using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Models;
using Newtonsoft.Json;

namespace MyBlog.UI.ViewComponents
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public EducationViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
            var responseMessage = await _httpClient.PostAsync("https://localhost:7200/Education/GetAll", null);
            //var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/Skills/GetAll", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<EducationGetDTO>>>(jsonData);
				//var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<SkillsGetDTO>>>(jsonData2);
				//EducationModel model = new EducationModel()
    //            {
    //                Education = value,
    //                //Skills = value2
    //            };
                //_httpClient.DefaultRequestHeaders.Remove("Authorization");
                return View(value);
            }

            return View();
        }
    }
}
