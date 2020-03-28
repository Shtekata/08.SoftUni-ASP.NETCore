using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAspNetCoreApp.TagHelpers
{
    [HtmlTargetElement("h1", Attributes ="greeting-string")]
    [HtmlTargetElement("h2", Attributes = "greeting-string")]
    [HtmlTargetElement("h3", Attributes = "greeting-string")]
    [HtmlTargetElement("h4", Attributes = "greeting-string")]
    public class GreetingHeaderTagHelper : TagHelper
    {
        public string GreetingString { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("name", "Asen");
            output.Content.SetContent(GreetingString);
            //output.PreContent.SetHtmlContent("<h1>Prac</h1>");
            output.PreContent.AppendHtml("<h1>Prac</h1>");
            base.Process(context, output);
        }
    }
}
