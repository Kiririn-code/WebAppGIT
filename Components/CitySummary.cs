using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Components
{
	public class CitySummary : ViewComponent
	{
		private CitiesData data;

        public CitySummary(CitiesData dt)
        {
			data= dt;
        }
		public IViewComponentResult Invoke(string themeName)
        {
			ViewBag.Theme = themeName;
			return View(new CityViewModel { Cities = data.Cities.Count(), Population = data.Cities.Sum(ctx => ctx.Population) });
        }
	}
}

