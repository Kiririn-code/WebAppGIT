using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components
{
	public class PageSize : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
        {
			HttpClient client = new HttpClient();
			HttpResponseMessage responseMessage = await client.GetAsync("http://apress.com");
			return View(responseMessage.Content.Headers.ContentLength);
        }
	}
}

