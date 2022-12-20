﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApp.Models;

namespace WebApp
{
	public class TestMiddleware
	{
		private RequestDelegate nextDelegate;
		public TestMiddleware( RequestDelegate next)
		{
			nextDelegate = next;
		}

		public async Task Invoke(HttpContext context,DataContext dataContext)
        {
			if(context.Request.Path == "/test")
            {
				await context.Response.WriteAsync($"They are {dataContext.Products.Count()} products \n");
				await context.Response.WriteAsync($"They are {dataContext.Categories.Count()} categories \n");
				await context.Response.WriteAsync($"They are {dataContext.Suppliers.Count()} supplies \n");
            }
            else
            {
				await nextDelegate(context);
            }
        }
	}
}

