#pragma checksum "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7069ad85829d7f612b73b58c32c2a1f51a1e1cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reasons_Index), @"mvc.1.0.view", @"/Views/Reasons/Index.cshtml")]
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
#line 1 "F:\Projects\WorkTest\BHProject\UX\Views\_ViewImports.cshtml"
using UX;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\WorkTest\BHProject\UX\Views\_ViewImports.cshtml"
using UX.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7069ad85829d7f612b73b58c32c2a1f51a1e1cc8", @"/Views/Reasons/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98dafe5503e016492711061efea160e28b5cbc54", @"/Views/_ViewImports.cshtml")]
    public class Views_Reasons_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UX.ViewModels.UserReasonsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"Content\">\r\n\r\n    <h1>Reasons</h1>\r\n");
#nullable restore
#line 10 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
     foreach (var reason in Model.UserReasonsViewModels.ToArray())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"reason-container\">\r\n            <div class=\"reason\">\r\n                <div class=\"reason-preview\">\r\n                    <h6><img");
            BeginWriteAttribute("src", " src=\"", 403, "\"", 438, 1);
#nullable restore
#line 15 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
WriteAttributeValue("", 409, reason.appUserModel.ImageUrl, 409, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></h6>\r\n                    <h2>");
#nullable restore
#line 16 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
                    Write(reason.appUserModel.FirstName + " " + reason.appUserModel.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n                </div>\r\n                <div class=\"reason-info\">\r\n\r\n                    <h2>");
#nullable restore
#line 21 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
                   Write(reason.appReasonModel.ReasonTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <h6>");
#nullable restore
#line 22 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"
                   Write(reason.appReasonModel.ReasonDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 26 "F:\Projects\WorkTest\BHProject\UX\Views\Reasons\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n   \r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UX.ViewModels.UserReasonsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
