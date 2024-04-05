using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.CertificateDTO;
using MyBlog.Entity.DTO.PortfolioDTO;
using MyBlog.Entity.Result;
using MyBlog.UI.Models;
using Newtonsoft.Json;

namespace MyBlog.UI.ViewComponents
{
	public class PortfolioViewComponent:ViewComponent
	{
		private readonly HttpClient _httpClient;

		public PortfolioViewComponent(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
			var responseMessage = await _httpClient.PostAsync("https://localhost:7200/Portfolio/GetAll", null);
			var responseMessage2 = await _httpClient.PostAsync("https://localhost:7200/Certificate/GetAll", null);

			if (responseMessage.IsSuccessStatusCode&& responseMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UIResponse<IEnumerable<PortfolioGetDTO>>>(jsonData);
				var value2 = JsonConvert.DeserializeObject<UIResponse<IEnumerable<CertificateGetDTO>>>(jsonData2);
                PortfolioCertificateModel model = new PortfolioCertificateModel()
                {
                    Portfolio = value,
                    Certificate = value2
                };
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return View(model);
            }

			return View();
		}
	}
}
