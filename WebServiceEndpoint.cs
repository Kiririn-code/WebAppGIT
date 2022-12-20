using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;

namespace Microsoft.AspNetCore.Builder
{
	public static class WebServiceEndpoint
	{
		private static string BASEURL = "api/products";
		public static void MapWebService(this IEndpointRouteBuilder app)
        {
			app.MapGet($"{BASEURL}/{{id}}", async context =>
			{
				long key = long.Parse(context.Request.RouteValues["id"] as string);
				DataContext dataContext = context.RequestServices.GetService<DataContext>();
				Product p = dataContext.Products.Find(key);
				if (p == null)
				{
					context.Response.StatusCode = StatusCodes.Status404NotFound;
				}
				else
				{
					context.Response.ContentType = "application/json";
					await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(p));
				}

			});

			app.MapGet(BASEURL, async context =>
			{
				DataContext dataContext = context.RequestServices.GetService<DataContext>();
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(dataContext.Products));
			});

			app.MapPost(BASEURL, async context =>
			{
				DataContext dataContext = context.RequestServices.GetService<DataContext>();
				Product p = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
				await dataContext.AddAsync(p);
				await dataContext.SaveChangesAsync();
				context.Response.StatusCode = StatusCodes.Status200OK;
			});
        }
	}
}

