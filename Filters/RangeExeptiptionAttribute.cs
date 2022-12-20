using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Filters
{
	public class RangeExeptiptionAttribute : ExceptionFilterAttribute
	{
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "/Views/Shared/Message.cshtml",
                    ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
                    (
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary()
                    )
                    {
                        Model = @"The data recived bu the application cannot be processed"
                    }
                };
            }
        }
    }
}

