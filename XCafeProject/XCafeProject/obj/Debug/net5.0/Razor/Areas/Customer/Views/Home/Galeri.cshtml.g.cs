#pragma checksum "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Galeri.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b83f8153b538c53199966e478ae2fcdd40b99cc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Galeri), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Galeri.cshtml")]
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
#line 1 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\_ViewImports.cshtml"
using XCafeProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\_ViewImports.cshtml"
using XCafeProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b83f8153b538c53199966e478ae2fcdd40b99cc6", @"/Areas/Customer/Views/Home/Galeri.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23d3b741c8577ad67b4009134edaa9c4a011c9a5", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_Home_Galeri : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<XCafeProject.Models.Galeri>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-show-gallery flex-c-m fa fa-search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/pato-master/images/photo-gallery-13.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-lightbox", new global::Microsoft.AspNetCore.Html.HtmlString("gallery"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Galeri.cshtml"
  
    ViewData["Title"] = "Galeri";
    Layout = "~/Views/Shared/_SiteLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Title Page -->
	<section class=""bg-title-page flex-c-m p-t-160 p-b-80 p-l-15 p-r-15"" style=""background-image: url(/pato-master/images/bg-title-page-02.jpg);"">
		<h2 class=""tit6 t-center"">
			Galeri
		</h2>
	</section>



	<!-- Gallery -->
	<div class=""section-gallery p-t-118 p-b-100"">
		

		<div class=""wrap-gallery isotope-grid flex-w p-l-25 p-r-25"">
			<!-- - -->
");
#nullable restore
#line 22 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Galeri.cshtml"
             foreach (var item in Model)
		   {

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t   <div class=\"item-gallery isotope-item bo-rad-10 hov-img-zoom events guests\">\r\n\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 661, "\"", 678, 1);
#nullable restore
#line 25 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Galeri.cshtml"
WriteAttributeValue("", 667, item.Image, 667, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"IMG-GALLERY\">\r\n\r\n\t\t\t\t<div class=\"overlay-item-gallery trans-0-4 flex-c-m\">\r\n\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b83f8153b538c53199966e478ae2fcdd40b99cc65852", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t</div>\n");
#nullable restore
#line 31 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Galeri.cshtml"
		   }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\r\n\r\n\t\t\t\r\n\t\t</div>\r\n\r\n\t\t\r\n\t</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<XCafeProject.Models.Galeri>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
