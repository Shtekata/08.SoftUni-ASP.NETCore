#pragma checksum "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\Internal\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75be39449e0338499ab5b294923c01ffb20cca00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Internal_Test), @"mvc.1.0.razor-page", @"/Pages/Internal/Test.cshtml")]
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
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\_ViewImports.cshtml"
using MyFirstAspNetCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/softuni/{name:cyrillic?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75be39449e0338499ab5b294923c01ffb20cca00", @"/Pages/Internal/Test.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b6415bdada65f643b66344c8f4b49f222dd3b5f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Internal_Test : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 10 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\Internal\Test.cshtml"
  
    ViewData["Title"] = "Test";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Test</h1>\r\n<h1>");
#nullable restore
#line 15 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\14. ADVANCED TOPICS\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Pages\Internal\Test.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyFirstAspNetCoreApp.Pages.Internal.TestModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyFirstAspNetCoreApp.Pages.Internal.TestModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyFirstAspNetCoreApp.Pages.Internal.TestModel>)PageContext?.ViewData;
        public MyFirstAspNetCoreApp.Pages.Internal.TestModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
