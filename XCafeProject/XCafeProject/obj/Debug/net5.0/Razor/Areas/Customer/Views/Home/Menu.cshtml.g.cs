#pragma checksum "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13f9d7002b55529776bf4afe360f3bce015fb3ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Menu), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Menu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f9d7002b55529776bf4afe360f3bce015fb3ec", @"/Areas/Customer/Views/Home/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23d3b741c8577ad67b4009134edaa9c4a011c9a5", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_Home_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<XCafeProject.Models.Menu>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
  
    ViewData["Title"] = "Menu";
    Layout = "~/Views/Shared/_SiteLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""bg-title-page flex-c-m p-t-160 p-b-80 p-l-15 p-r-15"" style=""background-image: url(/pato-master/images/bg-title-page-01.jpg);"">
    <h2 class=""tit6 t-center"">
        Menü Listesi
    </h2>
</section>

<!-- Gallery -->
<div class=""section-gallery p-t-20"">
    ");
#nullable restore
#line 15 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
Write(await Component.InvokeAsync("CategoryList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<section class=\"section-lunch bgwhite\">\r\n\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row p-t-10\">\r\n            <div class=\"col-md-12 col-lg-6\">\r\n                <!-- Block3 -->\r\n");
#nullable restore
#line 25 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"blo3 flex-w flex-col-l-sm m-b-30\">\r\n                    <div class=\"pic-blo3 size20 bo-rad-10 hov-img-zoom m-r-28\">\r\n                        <a href=\"#\"><img");
            BeginWriteAttribute("src", " src=\"", 919, "\"", 936, 1);
#nullable restore
#line 29 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
WriteAttributeValue("", 925, item.Image, 925, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"IMG-MENU\"></a>\r\n                    </div>\r\n\r\n                    <div class=\"text-blo3 size21 flex-col-l-m\">\r\n                        <a href=\"#\" class=\"txt21 m-b-3\">\r\n                            ");
#nullable restore
#line 34 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n\r\n                        <span class=\"txt23\">\r\n                            ");
#nullable restore
#line 38 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n\r\n                        <span class=\"txt22 m-t-20\">\r\n                            ");
#nullable restore
#line 42 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
                       Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₺\r\n                        </span>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 46 "D:\VSProjeler\Core5\XCafeProject\XCafeProject\Areas\Customer\Views\Home\Menu.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n\r\n            </div>\r\n\r\n            \r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<XCafeProject.Models.Menu>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
