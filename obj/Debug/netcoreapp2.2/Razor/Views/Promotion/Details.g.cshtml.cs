#pragma checksum "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4212b7c0e9e9f06cb49688cdf0a590bb0cbb1336"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Promotion_Details), @"mvc.1.0.view", @"/Views/Promotion/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Promotion/Details.cshtml", typeof(AspNetCore.Views_Promotion_Details))]
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
#line 1 "/Users/mac/sieuthidienthoai/Views/_ViewImports.cshtml"
using SieuThiDienThoai;

#line default
#line hidden
#line 2 "/Users/mac/sieuthidienthoai/Views/_ViewImports.cshtml"
using SieuThiDienThoai.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4212b7c0e9e9f06cb49688cdf0a590bb0cbb1336", @"/Views/Promotion/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b56cf568cdb630b8771c75c3367455adffedcc3", @"/Views/_ViewImports.cshtml")]
    public class Views_Promotion_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SieuThiDienThoai.Models.Promotion>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(82, 124, true);
            WriteLiteral("\n<h1>Details</h1>\n\n<div>\n    <h4>Promotion</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(207, 40, false);
#line 14 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(247, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(308, 36, false);
#line 17 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(344, 59, true);
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(404, 40, false);
#line 20 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(444, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(505, 36, false);
#line 23 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(541, 59, true);
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(601, 45, false);
#line 26 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
            EndContext();
            BeginContext(646, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(707, 41, false);
#line 29 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.StartTime));

#line default
#line hidden
            EndContext();
            BeginContext(748, 59, true);
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(808, 43, false);
#line 32 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EndTime));

#line default
#line hidden
            EndContext();
            BeginContext(851, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(912, 39, false);
#line 35 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.EndTime));

#line default
#line hidden
            EndContext();
            BeginContext(951, 59, true);
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(1011, 41, false);
#line 38 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Value));

#line default
#line hidden
            EndContext();
            BeginContext(1052, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(1113, 37, false);
#line 41 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.Value));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 59, true);
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            EndContext();
            BeginContext(1210, 49, false);
#line 44 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MinTotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1259, 60, true);
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            EndContext();
            BeginContext(1320, 45, false);
#line 47 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
       Write(Html.DisplayFor(model => model.MinTotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1365, 42, true);
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
            EndContext();
            BeginContext(1407, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4212b7c0e9e9f06cb49688cdf0a590bb0cbb13368690", async() => {
                BeginContext(1453, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "/Users/mac/sieuthidienthoai/Views/Promotion/Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1461, 7, true);
            WriteLiteral(" |\n    ");
            EndContext();
            BeginContext(1468, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4212b7c0e9e9f06cb49688cdf0a590bb0cbb133610953", async() => {
                BeginContext(1490, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1506, 8, true);
            WriteLiteral("\n</div>\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SieuThiDienThoai.Models.Promotion> Html { get; private set; }
    }
}
#pragma warning restore 1591
