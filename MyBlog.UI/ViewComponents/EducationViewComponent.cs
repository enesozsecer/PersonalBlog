using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.EducationDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.DTO.WorkDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/Work/GetAll", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<EducationGetDTO>>>(jsonData);
                var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<WorkGetDTO>>>(jsonData2);
                value.Data = value.Data.OrderByDescending(item => item.EndingDate);
                value2.Data = value2.Data.OrderByDescending(item => item.EndingDate);

                EducationWorkModel model = new EducationWorkModel()
                {
                    Education = value,
                    Work = value2
                };
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return View(model);
            }

            return View();
        }
    }
}
