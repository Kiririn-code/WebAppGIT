using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
namespace WebApp.TagHelpers
{
	public class TimeTagHelperComponent : TagHelperComponent
	{
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string timeStamp = DateTime.Now.ToLongTimeString();

            if(output.TagName == "body")
            {
                TagBuilder elem = new TagBuilder("div");
                elem.Attributes.Add("class", "bg-info text-white m-2 p-2");
                elem.InnerHtml.Append($"Time:{timeStamp}");
                output.PreContent.AppendHtml(elem);
            }
        }
    }
}

