#pragma checksum "C:\Users\moham\source\repos\FWshop\FWshop\Areas\ContectUS\Views\ConMail\SendMail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "400dfcba5a5642d9104e603d3d3cf5fb9ec8e367"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ContectUS_Views_ConMail_SendMail), @"mvc.1.0.view", @"/Areas/ContectUS/Views/ConMail/SendMail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"400dfcba5a5642d9104e603d3d3cf5fb9ec8e367", @"/Areas/ContectUS/Views/ConMail/SendMail.cshtml")]
    #nullable restore
    public class Areas_ContectUS_Views_ConMail_SendMail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FWshop.Areas.ContectUS.Models.ConMail>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\moham\source\repos\FWshop\FWshop\Areas\ContectUS\Views\ConMail\SendMail.cshtml"
  
    ViewData["Title"] = "Send Mail";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3 style=\"color:red\">\r\n     ");
#nullable restore
#line 7 "C:\Users\moham\source\repos\FWshop\FWshop\Areas\ContectUS\Views\ConMail\SendMail.cshtml"
Write(TempData["Mess"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</h3>
<h1>Send Mail</h1>
<form  asp-controller=""ConMail"" asp-action=""SendMail"" method=""post"">

    <label asp-for=""Title"">Title</label>
    <input type=""text"" asp-for=""Title"" class= ""form-control""/>
    <span class=""text-danger"" asp-validation-for=""Title""></span>
    <br><br>
    <label asp-for=""Message"">Message</label>
    <textarea asp-for=""Message"" class= ""form-control"" rows=""4""></textarea>
    <span class=""text-danger"" asp-validation-for=""Message""></span>
    <br><br>
    
     <input type=""submit"" value=""Send"" class=""btn btn-primary""/>
</form>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FWshop.Areas.ContectUS.Models.ConMail> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
