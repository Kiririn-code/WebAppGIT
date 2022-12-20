using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace WebApp.TagHelpers
{
    [HtmlTargetElement("div",Attributes ="[route-data=true]")]
	public class RouteDataTagHelper : TagHelper
	{
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "bg-primary m-2 p-2");

            TagBuilder list = new TagBuilder("ul");
            list.Attributes["class"] = "list-group";
            RouteValueDictionary rd = Context.RouteData.Values;

            if(rd.Count > 0)
            {
                foreach (var item in rd)
                {
                    TagBuilder elementOfList = new TagBuilder("li");
                    elementOfList.Attributes["class"] = "list-group-item";
                    elementOfList.InnerHtml.Append($"{item.Key} - {item.Value}");
                    list.InnerHtml.AppendHtml(elementOfList);
                }
                output.Content.AppendHtml(list);
            }
            else
            {
                output.Content.Append("No route data");
            }
        }
    }
}

