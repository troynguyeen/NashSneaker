#pragma checksum "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shopping_Index), @"mvc.1.0.view", @"/Views/Shopping/Index.cshtml")]
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
#line 1 "C:\NashSneaker\nashsneaker_netcore\Views\_ViewImports.cshtml"
using NashSneaker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NashSneaker\nashsneaker_netcore\Views\_ViewImports.cshtml"
using NashSneaker.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c3bd1307ab84f7a2a08bd7c534ba1693524a66c", @"/Views/Shopping/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fcf8e2f44efb1a14876b9e4761e9f7e9df456a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shopping_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NashSneaker.Data.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section class=""page-header"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""content"">
                    <h1 class=""page-name"">Shop</h1>
                    <ol class=""breadcrumb"" style=""font-size: 14px;"">
                        <li><a");
            BeginWriteAttribute("href", " href=\"", 364, "\"", 399, 1);
#nullable restore
#line 10 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
WriteAttributeValue("", 371, Url.Action("Index", "Home"), 371, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n");
#nullable restore
#line 11 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                         if (Model.ElementAt(0).Category.Name == null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"active\">All Shoes</li>\r\n");
#nullable restore
#line 14 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"active\">");
#nullable restore
#line 17 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                                          Write(Model.ElementAt(0).Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 18 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </ol>
                </div>
            </div>
        </div>
    </div>
</section>


<section class=""products section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-3"">
                <div class=""widget"">
                    <h4 class=""widget-title"">Short By</h4>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c6175", async() => {
                WriteLiteral("\r\n                        <select class=\"form-control\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c6520", async() => {
                    WriteLiteral("Man");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c7559", async() => {
                    WriteLiteral("Women");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c8600", async() => {
                    WriteLiteral("Accessories");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c3bd1307ab84f7a2a08bd7c534ba1693524a66c9647", async() => {
                    WriteLiteral("Shoes");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </select>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""widget product-category"">
                    <h4 class=""widget-title"">Categories</h4>
                    <div class=""panel-group commonAccordion"" id=""accordion"" role=""tablist"" aria-multiselectable=""true"">
                        <div class=""panel panel-default"">
                            <div class=""panel-heading"" role=""tab"" id=""headingOne"">
                                <h4 class=""panel-title"">
                                    <a role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne"" aria-expanded=""true"" aria-controls=""collapseOne"">
                                        Shoes
                                    </a>
                                </h4>
                            </div>
                            <div id=""collapseOne"" class=""panel-collapse collapse in"" role=""tabpanel"" aria-labelledby=""headingOne"">
                                <div class=""panel-body"">
                                 ");
            WriteLiteral(@"   <ul>
                                        <li><a href=""#!"">Brand & Twist</a></li>
                                        <li><a href=""#!"">Shoe Color</a></li>
                                        <li><a href=""#!"">Shoe Color</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class=""panel panel-default"">
                            <div class=""panel-heading"" role=""tab"" id=""headingTwo"">
                                <h4 class=""panel-title"">
                                    <a class=""collapsed"" role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseTwo"" aria-expanded=""false"" aria-controls=""collapseTwo"">
                                        Duty Wear
                                    </a>
                                </h4>
                            </div>
                            <div id=""collapseTwo"" class=""panel-coll");
            WriteLiteral(@"apse collapse"" role=""tabpanel"" aria-labelledby=""headingTwo"">
                                <div class=""panel-body"">
                                    <ul>
                                        <li><a href=""#!"">Brand & Twist</a></li>
                                        <li><a href=""#!"">Shoe Color</a></li>
                                        <li><a href=""#!"">Shoe Color</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class=""panel panel-default"">
                            <div class=""panel-heading"" role=""tab"" id=""headingThree"">
                                <h4 class=""panel-title"">
                                    <a class=""collapsed"" role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseThree"" aria-expanded=""false"" aria-controls=""collapseThree"">
                                        WorkOut Shoes
                     ");
            WriteLiteral(@"               </a>
                                </h4>
                            </div>
                            <div id=""collapseThree"" class=""panel-collapse collapse"" role=""tabpanel"" aria-labelledby=""headingThree"">
                                <div class=""panel-body"">
                                    <ul>
                                        <li><a href=""#!"">Brand & Twist</a></li>
                                        <li><a href=""#!"">Shoe Color</a></li>
                                        <li><a href=""#!"">Gladian Shoes</a></li>
                                        <li><a href=""#!"">Swis Shoes</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <div class=""col-md-9"">
                <div class=""row"">
");
#nullable restore
#line 106 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                     if (Model.ElementAt(0).Id != 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-4\">\r\n                                <div class=\"product-item\">\r\n                                    <div class=\"product-thumb\">\r\n                                        <img class=\"img-responsive\"");
            BeginWriteAttribute("src", " src=\"", 5916, "\"", 5969, 2);
            WriteAttributeValue("", 5922, "/images/products/", 5922, 17, true);
#nullable restore
#line 113 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
WriteAttributeValue("", 5939, item.Images.ElementAt(0).Path, 5939, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"product-img\" />\r\n                                        <div class=\"preview-meta\">\r\n                                            <ul>\r\n                                                <li>\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 6219, "\"", 6281, 1);
#nullable restore
#line 117 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
WriteAttributeValue("", 6226, Url.Action("Detail", "Shopping", new { id = item.Id }), 6226, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"tf-ion-ios-search-strong\"></i></a>\r\n                                                </li>\r\n                                                <li>\r\n                                                    <a");
            BeginWriteAttribute("href", " href=\"", 6492, "\"", 6554, 1);
#nullable restore
#line 120 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
WriteAttributeValue("", 6499, Url.Action("Detail", "Shopping", new { id = item.Id }), 6499, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""tf-ion-android-cart""></i></a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class=""product-content"">
                                        <h4><a href=""product-single.html"">");
#nullable restore
#line 126 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                                        <p class=\"price\">");
#nullable restore
#line 127 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                                                    Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 131 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 131 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NashSneaker.Data.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
