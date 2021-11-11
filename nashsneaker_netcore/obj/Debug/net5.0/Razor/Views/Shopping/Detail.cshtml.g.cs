#pragma checksum "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88b785126c304ef758afed6ab51c32353dc49c58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shopping_Detail), @"mvc.1.0.view", @"/Views/Shopping/Detail.cshtml")]
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
#nullable restore
#line 1 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
using NashSneaker.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88b785126c304ef758afed6ab51c32353dc49c58", @"/Views/Shopping/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fcf8e2f44efb1a14876b9e4761e9f7e9df456a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shopping_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NashSneaker.Data.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home/pg5.jfif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home/freak3.jfif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home/alphafly_1.jfif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home/one_take.jfif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Header.cshtml";

    float ratingProduct = 0;

    foreach (var item in Model.Ratings)
    {
        ratingProduct += item.Level;
    }

    ratingProduct = ratingProduct / Model.Ratings.Count();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""page-header"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""content"">
                    <h1 class=""page-name"">Shop</h1>
                    <ol class=""breadcrumb"">
                        <li><a");
            BeginWriteAttribute("href", " href=\"", 701, "\"", 736, 1);
#nullable restore
#line 28 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 708, Url.Action("Index", "Home"), 708, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n                        <li><a");
            BeginWriteAttribute("href", " href=\"", 783, "\"", 866, 1);
#nullable restore
#line 29 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 790, Url.Action("Index", "Shopping", new { categoryName = Model.Category.Name }), 790, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 29 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                                                              Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li class=\"active\">");
#nullable restore
#line 30 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</section>
<section class=""single-product"">
    <div class=""container"">
        <div class=""row mt-20"">
            <div class=""col-md-5"">
                <div class=""single-product-slider"">
                    <div id='carousel-custom' class='carousel slide' data-ride='carousel'>
                        <div class='carousel-outer'>
                            <div class='carousel-inner '>
                                <div class='item active'>
                                    <img");
            BeginWriteAttribute("src", " src=\"", 1560, "\"", 1597, 1);
#nullable restore
#line 46 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 1566, Model.Images.ElementAt(0).Path, 1566, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1598, "\"", 1604, 0);
            EndWriteAttribute();
            WriteLiteral(" data-zoom-image=\"");
#nullable restore
#line 46 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                                                  Write(Model.Images.ElementAt(0).Path);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n                                </div>\r\n");
#nullable restore
#line 48 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                 for (int i = 1; i < Model.Images.Count(); i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\'item\'>\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1916, "\"", 1953, 1);
#nullable restore
#line 51 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 1922, Model.Images.ElementAt(i).Path, 1922, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1954, "\"", 1960, 0);
            EndWriteAttribute();
            WriteLiteral(" data-zoom-image=\"");
#nullable restore
#line 51 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                                                      Write(Model.Images.ElementAt(i).Path);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n                                    </div>\r\n");
#nullable restore
#line 53 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <!-- sag sol -->
                            <a class='left carousel-control' href='#carousel-custom' data-slide='prev'>
                                <i class=""tf-ion-ios-arrow-left""></i>
                            </a>
                            <a class='right carousel-control' href='#carousel-custom' data-slide='next'>
                                <i class=""tf-ion-ios-arrow-right""></i>
                            </a>
                        </div>
                        <!-- thumb -->
                        <ol class='carousel-indicators mCustomScrollbar meartlab'>
                            <li data-target='#carousel-custom' data-slide-to='0' class='active'>
                                <img");
            BeginWriteAttribute("src", " src=\'", 2889, "\'", 2926, 1);
#nullable restore
#line 66 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 2895, Model.Images.ElementAt(0).Path, 2895, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\'", 2927, "\'", 2933, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </li>\r\n");
#nullable restore
#line 68 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                             for (int i = 1; i < Model.Images.Count(); i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li data-target=\'#carousel-custom\' data-slide-to=");
#nullable restore
#line 70 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\'", 3208, "\'", 3245, 1);
#nullable restore
#line 71 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
WriteAttributeValue("", 3214, Model.Images.ElementAt(i).Path, 3214, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\'", 3246, "\'", 3252, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </li>\r\n");
#nullable restore
#line 73 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ol>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7\">\r\n                <div class=\"single-product-details\" name=\"productId\" data-content=\"");
#nullable restore
#line 79 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                              Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    <h2>");
#nullable restore
#line 80 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <p class=\"product-price\" style=\"font-size: 18px;\">");
#nullable restore
#line 81 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                                 Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</p>\r\n                    <div class=\'rating-stars\'>\r\n                        <ul id=\'stars\' data-content=\"");
#nullable restore
#line 83 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                Write(ratingProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                            <li class='star' title='Poor' data-value='1'>
                                <i class='fa fa-star fa-fw'></i>
                            </li>
                            <li class='star' title='Fair' data-value='2'>
                                <i class='fa fa-star fa-fw'></i>
                            </li>
                            <li class='star' title='Good' data-value='3'>
                                <i class='fa fa-star fa-fw'></i>
                            </li>
                            <li class='star' title='Excellent' data-value='4'>
                                <i class='fa fa-star fa-fw'></i>
                            </li>
                            <li class='star' title='WOW!!!' data-value='5'>
                                <i class='fa fa-star fa-fw'></i>
                            </li>
                        </ul>
                    </div>
                    <div class=""product-category"">
                      ");
            WriteLiteral("  <span>Categories:</span>\r\n                        <ul style=\"padding: 0px;\">\r\n                            <li style=\"margin: 0px;\">");
#nullable restore
#line 104 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                                Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>
                    </div>
                    <div class=""product-size"">
                        <span>Size:</span>
                        <select class=""form-control"" style=""width: auto; letter-spacing: unset; padding: 6px;"" id=""dropDownSize"">
");
#nullable restore
#line 110 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                             foreach (var item in Model.Sizes)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88b785126c304ef758afed6ab51c32353dc49c5817104", async() => {
#nullable restore
#line 112 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 113 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                    <div class=""product-quantity"">
                        <span>Quantity:</span>
                        <div class=""product-quantity-slider"">
                            <input id=""product-quantity"" type=""number"" value=""1"" min=""1"" max=""10"" name=""product-quantity"">
                        </div>
                    </div>
                    <a class=""btn btn-main mt-20"" onclick=""AddtoCart()"">Add To Cart</a>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""tabCommon mt-20"">
                    <ul class=""nav nav-tabs"">
                        <li class=""active""><a data-toggle=""tab"" href=""#details"" aria-expanded=""true"">Details</a></li>
                    </ul>
                    <div class=""tab-content patternbg"">
                        <div id=""details"" class=""tab-pane fade active in"">
                            ");
            WriteLiteral("<h4>Product Description</h4>\r\n                            <p>");
#nullable restore
#line 135 "C:\NashSneaker\nashsneaker_netcore\Views\Shopping\Detail.cshtml"
                          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""products related-products section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""title text-center"">
                <h2>Related Products</h2>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-3"">
                <div class=""product-item"">
                    <div class=""product-thumb"">
                        <span class=""bage"">Sale</span>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88b785126c304ef758afed6ab51c32353dc49c5820461", async() => {
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
            WriteLiteral(@"
                        <div class=""preview-meta"">
                            <ul>
                                <li>
                                    <span data-toggle=""modal"" data-target=""#product-modal"">
                                        <i class=""tf-ion-ios-search""></i>
                                    </span>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-ios-heart""></i></a>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-android-cart""></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""product-content"">
                        <h4><a href=""product-single.html"">Reef Boardsport</a></h4>
                        <p class=""price"">$200</p>
                    </div>
      ");
            WriteLiteral("          </div>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                <div class=\"product-item\">\r\n                    <div class=\"product-thumb\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88b785126c304ef758afed6ab51c32353dc49c5822939", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <div class=""preview-meta"">
                            <ul>
                                <li>
                                    <span data-toggle=""modal"" data-target=""#product-modal"">
                                        <i class=""tf-ion-ios-search-strong""></i>
                                    </span>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-ios-heart""></i></a>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-android-cart""></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""product-content"">
                        <h4><a href=""product-single.html"">Rainbow Shoes</a></h4>
                        <p class=""price"">$200</p>
                    </div>
 ");
            WriteLiteral("               </div>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                <div class=\"product-item\">\r\n                    <div class=\"product-thumb\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88b785126c304ef758afed6ab51c32353dc49c5825422", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <div class=""preview-meta"">
                            <ul>
                                <li>
                                    <span data-toggle=""modal"" data-target=""#product-modal"">
                                        <i class=""tf-ion-ios-search""></i>
                                    </span>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-ios-heart""></i></a>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-android-cart""></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""product-content"">
                        <h4><a href=""product-single.html"">Strayhorn SP</a></h4>
                        <p class=""price"">$230</p>
                    </div>
         ");
            WriteLiteral("       </div>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                <div class=\"product-item\">\r\n                    <div class=\"product-thumb\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88b785126c304ef758afed6ab51c32353dc49c5827897", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <div class=""preview-meta"">
                            <ul>
                                <li>
                                    <span data-toggle=""modal"" data-target=""#product-modal"">
                                        <i class=""tf-ion-ios-search""></i>
                                    </span>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-ios-heart""></i></a>
                                </li>
                                <li>
                                    <a href=""#!""><i class=""tf-ion-android-cart""></i></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""product-content"">
                        <h4><a href=""product-single.html"">Bradley Mid</a></h4>
                        <p class=""price"">$200</p>
                    </div>
          ");
            WriteLiteral(@"      </div>
            </div>

        </div>
    </div>
</section>

<script type=""text/javascript"">
    function AddtoCart() {
        var userId = $(""li[name=userAccount]"").attr(""data-content"");
        var productId = parseInt($(""div[name=productId]"").attr(""data-content""));
        var quantity = parseInt($(""#product-quantity"").val());
        var size = parseInt($(""#dropDownSize"").val());

        if (userId != """") {

            $.ajax({
                async: true,
                type: 'POST',
                data: {
                    userId: userId,
                    productId: productId,
                    quantity: quantity,
                    size: size
                },
                dataType: ""text"",
                url: '/Cart/AddItemToCart',
                success: function (data) {
                    const obj = JSON.parse(data);
                    $(""#cartCount"").text(obj.cartCounter);

                    if (obj.message != """") {
                ");
            WriteLiteral(@"        alert(obj.message);
                    }
                },
                error: function () {
                    console.log(""error"")
                }
            })
        }
        else {
            alert(""Bạn cần phải đăng nhập!"");
        }
    }


    $(document).ready(function () {

        $(""input[name=product-quantity]"").change(function () {
            var quantity = $(""#product-quantity"").val();

            if (quantity < 1) {
                alert(""Số lượng mua phải ít nhất là 1!"");
                $(""#product-quantity"").val(1);
            }
            else if (quantity > 10) {
                alert(""Số lượng mua không được lớn hơn 10!"");
                $(""#product-quantity"").val(10);
            }
        })

        //get start on db
        var level = parseInt($(""#stars"").attr(""data-content""));
        var listStart = $(""#stars li"").parent().children('li.star');

        for (var j = 0; j < level; j++) {
            $(listStart[j]).addClass");
            WriteLiteral(@"('selected');
        }

        /* 1. Visualizing things on Hover - See next part for action on click */
        $('#stars li').on('mouseover', function () {
            var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

            // Now highlight all the stars that's not after the current hovered star
            $(this).parent().children('li.star').each(function (e) {
                if (e < onStar) {
                    $(this).addClass('hover');
                }
                else {
                    $(this).removeClass('hover');
                }
            });

        }).on('mouseout', function () {
            $(this).parent().children('li.star').each(function (e) {
                $(this).removeClass('hover');
            });
        });

        /* 2. Action to perform on click */
        $('#stars li').on('click', function () {
            var userId = $(""li[name=userAccount]"").attr(""data-content"");
            var productId = parseI");
            WriteLiteral(@"nt($(""div[name=productId]"").attr(""data-content""));

            if (userId != """") {
                var onStar = parseInt($(this).data('value'), 10); // The star currently selected
                var stars = $(this).parent().children('li.star');

                for (i = 0; i < stars.length; i++) {
                    $(stars[i]).removeClass('selected');
                }

                for (i = 0; i < onStar; i++) {
                    $(stars[i]).addClass('selected');
                }

                // JUST RESPONSE (Not needed)
                var ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);

                $.ajax({
                    async: true,
                    type: 'POST',
                    data: {
                        userId: userId,
                        productId: productId,
                        level: ratingValue
                    },
                    dataType: ""text"",
                    url: '/Shopping/Rating',
    ");
            WriteLiteral(@"                success: function () {
                        console.log(""success"")
                    },
                    error: function () {
                        console.log(""error"")
                    }
                })
            }
            else {
                alert(""Bạn cần phải đăng nhập!"");
            }
        });

    });
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NashSneaker.Data.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
