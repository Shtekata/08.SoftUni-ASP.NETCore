#pragma checksum "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57fff89027bdc82b33581912d5e5497acd40f0f0"
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
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\_ViewImports.cshtml"
using MyFirstAspNetCoreApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using MyFirstAspNetCoreApp.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
using System.Text.Encodings.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57fff89027bdc82b33581912d5e5497acd40f0f0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b6415bdada65f643b66344c8f4b49f222dd3b5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadInput", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
Write(Context.Request.Query["q"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57fff89027bdc82b33581912d5e5497acd40f0f05278", async() => {
                WriteLiteral("\r\n    <input name=\"data\" />\r\n    <input type=\"submit\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 18 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
   var untrustedInput = "<\"123\">";

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    document.write(\"");
#nullable restore
#line 20 "D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\13. PROJECT ARCHITECTURE\MyFirstAspNetCoreApp\MyFirstAspNetCoreApp\Views\Home\Index.cshtml"
               Write(encoder.Encode(untrustedInput));

#line default
#line hidden
#nullable disable
            WriteLiteral("\")\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UrlEncoder encoder3 { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public HtmlEncoder encoder2 { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public JavaScriptEncoder encoder { get; private set; }
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
