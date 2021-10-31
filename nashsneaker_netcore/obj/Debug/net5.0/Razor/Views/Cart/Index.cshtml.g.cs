#pragma checksum "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3d08520a038b91a3e5dbe87ee7f4d538853bf67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\NashSneaker\ASP.NET Core\Views\_ViewImports.cshtml"
using NashSneaker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NashSneaker\ASP.NET Core\Views\_ViewImports.cshtml"
using NashSneaker.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
using NashSneaker.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3d08520a038b91a3e5dbe87ee7f4d538853bf67", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fcf8e2f44efb1a14876b9e4761e9f7e9df456a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NashSneaker.Data.Cart>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
  
    Layout = "~/Views/Header.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    table {
        border-collapse: separate;
    }

    th, td {
        padding: 20px;
        text-align: left;
    }

    .product-list::-webkit-scrollbar {
        display: none; /* for Chrome, Safari, and Opera */
    }
</style>

<section class=""page-header"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""content"">
                    <h1 class=""page-name"">Cart</h1>
                    <ol class=""breadcrumb"">
                        <li><a");
            BeginWriteAttribute("href", " href=\"", 737, "\"", 772, 1);
#nullable restore
#line 34 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 744, Url.Action("Index", "Home"), 744, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Home</a></li>
                        <li class=""active"">Cart</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</section>

<div class=""page-wrapper"" style=""padding-top: 20px;"">
    <div class=""cart shopping"">
        <div class=""container"">
");
#nullable restore
#line 46 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
             if (Model != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row"" id=""hasItem"">
                    <div class=""col-md-8 col-md-offset-2"">
                        <div class=""block"">
                            <div class=""product-list"" style=""overflow-y: auto; height: 540px;"">
                                <table class=""table"">
                                    <thead style=""position: sticky; top: 0; background-color: #FFF;"">
                                        <tr>
                                            <th>Item Name</th>
                                            <th>Unit Price</th>
                                            <th>Quantity</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 62 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                         foreach (var item in Model.CartDetails)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr");
            BeginWriteAttribute("class", " class=\"", 2143, "\"", 2167, 1);
#nullable restore
#line 64 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2151, item.Product.Id, 2151, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-content=\"");
#nullable restore
#line 64 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                                                  Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                                <td>\r\n                                                    <div class=\"product-info\" style=\"display: flex; align-items: center;\">\r\n                                                        <img width=\"100\"");
            BeginWriteAttribute("src", " src=\"", 2447, "\"", 2491, 1);
#nullable restore
#line 67 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2453, item.Product.Images.ElementAt(0).Path, 2453, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"product\" />\r\n                                                        <div>\r\n                                                            <a");
            BeginWriteAttribute("href", " href=\"", 2636, "\"", 2739, 1);
#nullable restore
#line 69 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 2643, Url.Action("Detail", "Shopping", new { productName = item.Product.Name, id = item.Product.Id }), 2643, 96, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                ");
#nullable restore
#line 70 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                           Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                            </a>\r\n                                                            <div style=\"margin-left: 10px; padding-top: 10px;\">Size: ");
#nullable restore
#line 72 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                                                                                Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                                        </div>\r\n                                                    </div>\r\n                                                </td>\r\n                                                <td>");
#nullable restore
#line 76 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                               Write(item.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</td>\r\n                                                <td><input");
            BeginWriteAttribute("id", " id=\"", 3347, "\"", 3362, 1);
#nullable restore
#line 77 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3352, item.Size, 3352, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"number\"");
            BeginWriteAttribute("value", " value=\"", 3377, "\"", 3399, 1);
#nullable restore
#line 77 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3385, item.Quantity, 3385, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" min=\"1\" max=\"10\" style=\"width: 50px;\" name=\"quantity\"");
            BeginWriteAttribute("itemid", " itemid=\"", 3454, "\"", 3479, 1);
#nullable restore
#line 77 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3463, item.Product.Id, 3463, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-content=\"");
#nullable restore
#line 77 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                                                                                                                                                                         Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></td>\r\n                                                <td>\r\n                                                    <a href=\"#!\" class=\"product-remove\" style=\"margin-left: 20px;\" onclick=\"RemoveItem(this)\"");
            BeginWriteAttribute("itemid", " itemid=\"", 3709, "\"", 3734, 1);
#nullable restore
#line 79 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3718, item.Product.Id, 3718, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-content=\"");
#nullable restore
#line 79 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                                                                                                                                                 Write(item.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fas fa-trash\"></i></a>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 82 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                                <div style=""display: flex; justify-content: space-between; padding: 30px 0; border-top: 1px solid black; position: sticky; bottom: 0; background-color: #FFF;"">
                                    <span style=""font-weight: bold;"">Total</span>
                                    <span style=""color: #000"" name=""total"">");
#nullable restore
#line 87 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                                                                      Write(Model.TotalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</span>\r\n                                </div>\r\n                            </div>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4521, "\"", 4607, 1);
#nullable restore
#line 90 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 4528, Url.Action("Index", "Ordering", new { userId = @UserManager.GetUserId(User) }), 4528, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-main pull-right\">Checkout</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 94 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""cartInner"" style=""margin-top: -50px;"">
                    <div style=""display: flex; flex-direction: column; align-items: center;"">
                        <img src=""https://salt.tikicdn.com/desktop/img/mascot@2x.png"">
                        <h2 style=""padding-top: 10px;"">No Items Found!</h2>
                        <div style=""font-size: 20px; padding: 30px;"">Sorry mate... no items found inside your cart</div>
                        <a");
            BeginWriteAttribute("href", " href=\"", 5263, "\"", 5338, 1);
#nullable restore
#line 102 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
WriteAttributeValue("", 5270, Url.Action("Index", "Shopping", new { categoryName = "All Shoes" }), 5270, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-main pull-right\">Continue shopping</a>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 105 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>

<script>
    function RemoveItem(item) {
        var hasNoItem = `
        <div class=""cartInner"" style=""margin-top: -50px;"">
            <div style=""display: flex; flex-direction: column; align-items: center;"">
                <img src=""https://salt.tikicdn.com/desktop/img/mascot@2x.png"">
                <h2 style=""padding-top: 10px;"">No Items Found!</h2>
                <div style=""font-size: 20px; padding: 30px;"">Sorry mate... no items found inside your cart</div>
                <a href=""");
#nullable restore
#line 118 "C:\NashSneaker\ASP.NET Core\Views\Cart\Index.cshtml"
                    Write(Url.Action("Index", "Shopping", new { categoryName = "All Shoes" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""btn btn-main pull-right"">Continue shopping</a>
            </div>
        </div>`;

        var userId = $(""li[name=userAccount]"").attr(""data-content"");
        var productId = $(item).attr(""itemid"");
        var size = $(item).attr(""data-content"");

        $.ajax({
            async: true,
            type: 'DELETE',
            data: {
                userId: userId,
                productId: productId,
                size: size
            },
            dataType: ""text"",
            url: '/Cart/DeleteItemFromCart',
            success: function (data) {
                const obj = JSON.parse(data);

                $(""#cartCount"").text(obj.cartCounter);
                $(""span[name=total]"").text(obj.totalAmount + "" VND"");
                $(""."" + productId + ""[data-content="" + size + ""]"").remove();

                if (parseInt(obj.cartCounter) === 0) {
                    $(""#hasItem"").replaceWith($(hasNoItem));
                }

            },
            error:");
            WriteLiteral(@" function () {
                console.log(""error"")
            }
        })

    }


    $(document).ready(function () {
        $(""input[name=quantity]"").change(function () {
            var userId = $(""li[name=userAccount]"").attr(""data-content"");
            var productId = $(this).attr(""itemid"");
            var quantity = this.value;
            var size = $(this).attr(""data-content"");

            if (quantity < 1) {
                quantity = 1;
                alert(""Số lượng mua phải ít nhất là 1!"");
                $(""#"" + size + ""[itemid="" + productId + ""]"").val(quantity);
            }
            else if (quantity > 10) {
                quantity = 10;
                alert(""Số lượng mua không được lớn hơn 10!"");
                $(""#"" + size + ""[itemid="" + productId + ""]"").val(quantity);
            }

            $.ajax({
                async: true,
                type: 'PUT',
                data: {
                    userId: userId,
                    product");
            WriteLiteral(@"Id: productId,
                    quantity: quantity,
                    size: size
                },
                dataType: ""text"",
                url: '/Cart/UpdateItemInCart',
                success: function (data) {
                    const obj = JSON.parse(data);

                    $(""#cartCount"").text(obj.cartCounter);
                    $(""span[name=total]"").text(obj.totalAmount + "" VND"");

                },
                error: function () {
                    console.log(""error"")
                }
            })
        })
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NashSneaker.Data.Cart> Html { get; private set; }
    }
}
#pragma warning restore 1591