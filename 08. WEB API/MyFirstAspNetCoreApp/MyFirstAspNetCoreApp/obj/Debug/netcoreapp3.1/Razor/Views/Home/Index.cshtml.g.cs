#pragma checksum "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0eeea8a3700d9de5c6d1ac48fc543a3dd71e0a2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using MyFirstAspNetCoreApp.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\08. WEB API\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eeea8a3700d9de5c6d1ac48fc543a3dd71e0a2d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b6415bdada65f643b66344c8f4b49f222dd3b5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<button class=""btn btn-lg btn-primary"" onclick=""brat()"">Click me</button>
<div id=""placeholderElement""></div>

<script>
    function brat() {
        //alert(""hello guys!!!"");
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                //alert(this.responseText);
                //console.log(this.responseText);
                var data = JSON.parse(this.responseText);
                document.getElementById(""placeholderElement"").innerHTML = data.email;
            }
        }
        xhr.open(""GET"", ""/Test/JsonIndex"", true);
        xhr.send();
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
