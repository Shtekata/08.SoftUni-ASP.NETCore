#pragma checksum "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\404.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbfc9da16a05ebcb57e0d3feb1322c9cacc50f78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_404), @"mvc.1.0.view", @"/Views/Home/404.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbfc9da16a05ebcb57e0d3feb1322c9cacc50f78", @"/Views/Home/404.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b6415bdada65f643b66344c8f4b49f222dd3b5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_404 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\404.cshtml"
  
    ViewData["Title"] = "HttpError";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Not Found: ");
#nullable restore
#line 6 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\12. TESTING\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\404.cshtml"
          Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<img src=\"https://softuni.bg/Content/images/404animation.gif\" />\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
