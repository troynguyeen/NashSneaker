#pragma checksum "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fdef5b0353a48a9435581fcf0a9b6735366c3f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ordering_Index), @"mvc.1.0.view", @"/Views/Ordering/Index.cshtml")]
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
#line 1 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
using NashSneaker.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fdef5b0353a48a9435581fcf0a9b6735366c3f9", @"/Views/Ordering/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fcf8e2f44efb1a14876b9e4761e9f7e9df456a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Ordering_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NashSneaker.Data.Cart>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("icons_payment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icon/cash_payment.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("cash"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("32"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icon/debit-card.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("debit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
   
    var total = Model.TotalAmount + 15000;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .product-list::-webkit-scrollbar {
        display: none; /* for Chrome, Safari, and Opera */
    }

</style>

<div id=""checkoutPage"">
    <section class=""page-header"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""content"">
                        <h1 class=""page-name"">Checkout</h1>
                        <ol class=""breadcrumb"">
                            <li><a");
            BeginWriteAttribute("href", " href=\"", 674, "\"", 709, 1);
#nullable restore
#line 27 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
WriteAttributeValue("", 681, Url.Action("Index", "Home"), 681, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n                            <li><a");
            BeginWriteAttribute("href", " href=\"", 760, "\"", 842, 1);
#nullable restore
#line 28 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
WriteAttributeValue("", 767, Url.Action("Index", "Cart", new { userId = @UserManager.GetUserId(User) }), 767, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Cart</a></li>
                            <li class=""active"">Checkout</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class=""page-wrapper"">
        <div class=""checkout shopping"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-md-8"">
                        <div class=""block billing-details"">
                            <h4 class=""widget-title"">Billing Details</h4>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fdef5b0353a48a9435581fcf0a9b6735366c3f98253", async() => {
                WriteLiteral("\r\n                                <div class=\"form-group\">\r\n                                    <label for=\"RecipientName\">Recipient Name</label>\r\n                                    <input type=\"text\" class=\"form-control\" id=\"RecipientName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1678, "\"", 1692, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </div>
                                <div class=""form-group"">
                                    <label for=""PhoneNumber"">Phone Number</label>
                                    <input type=""text"" class=""form-control"" id=""PhoneNumber""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1969, "\"", 1983, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                </div>
                                <div class=""form-group"">
                                    <label for=""Address"">Address</label>
                                    <input type=""text"" class=""form-control"" id=""Address""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 2247, "\"", 2261, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""block"">
                            <h4 class=""widget-title"">Payment Method</h4>
                            <div class=""payments_list"">
                                <div class=""payments_selecting"">
                                    <ul id=""paymentChoice"">
                                        <li id=""cashPayment"" style=""padding-bottom: 10px;"">
                                            <div class=""custom-radio form-check"">
                                                <input class=""custom-radioInput form-check-input"" style=""margin: 5px;"" type=""radio"" name=""paymentSelecting"" id=""cash"" value=""cash"" checked>
                                                <label class=""custom-radioLabel form-check-label"" for=""cash"">
                                                    <div class=""item_payment"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0fdef5b0353a48a9435581fcf0a9b6735366c3f911934", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                        <span>Cash on delivery (COD)</span>
                                                    </div>
                                                </label>
                                            </div>
                                        </li>
                                        <li id=""cardPayment"" style=""padding-bottom: 10px;"">
                                            <div class=""custom-radio form-check"">
                                                <input class=""custom-radioInput form-check-input"" style=""margin: 5px;"" type=""radio"" name=""paymentSelecting"" id=""card"" value=""card"">
                                                <label class=""custom-radioLabel form-check-label"" for=""card"">
                                                    <div class=""item_payment"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0fdef5b0353a48a9435581fcf0a9b6735366c3f914152", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                        <span>Napas ATM/Internet Banking</span>
                                                    </div>
                                                </label>
                                            </div>
                                        </li>
                                        <li id=""momoPayment"" style=""padding-bottom: 10px;"">
                                            <div class=""custom-radio form-check"">
                                                <input class=""custom-radioInput form-check-input"" style=""margin: 5px;"" type=""radio"" name=""paymentSelecting"" id=""momo"" value=""momo"">
                                                <label class=""custom-radioLabel form-check-label"" for=""momo"">
                                                    <div class=""item_payment"">
                                                        <img class=""icons_payment"" src=""https://frontend.tikicdn.com/_desktop-next/static/img/icons/checkout/ico");
            WriteLiteral(@"n-payment-method-mo-mo.svg"" alt=""cash"" width=""32"">
                                                        <span>MoMo Wallet</span>
                                                    </div>
                                                </label>
                                            </div>
                                        </li>
                                    </ul>
                                    <a onclick=""PlaceOrder()"" class=""btn btn-main mt-20"">Place Order</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-4"">
                        <div class=""product-checkout-details"">
                            <div class=""block"">
                                <h4 class=""widget-title"">Order Summary</h4>
                                <div class=""product-list"" style=""overflow-y: auto; height: 200px;"">
");
#nullable restore
#line 107 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                     foreach (var item in Model.CartDetails)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"media product-card\">\r\n                                            <a class=\"pull-left\">\r\n                                                <img class=\"media-object\"");
            BeginWriteAttribute("src", " src=\"", 6688, "\"", 6732, 1);
#nullable restore
#line 111 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
WriteAttributeValue("", 6694, item.Product.Images.ElementAt(0).Path, 6694, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\" />\r\n                                            </a>\r\n                                            <div class=\"media-body\">\r\n                                                <h4 class=\"media-heading\"><a>");
#nullable restore
#line 114 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                                                        Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                                                <p class=\"price\">");
#nullable restore
#line 115 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                                            Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" x ");
#nullable restore
#line 115 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                                                             Write(item.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 118 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                                <hr />
                                <ul class=""summary-prices"">
                                    <li>
                                        <span>Subtotal:</span>
                                        <span class=""price"">");
#nullable restore
#line 124 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                                       Write(Model.TotalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VND</span>
                                    </li>
                                    <li>
                                        <span>Shipping:</span>
                                        <span><span id=""ShippingFee"">15000</span> VND</span>
                                    </li>
                                </ul>
                                <div class=""summary-total"">
                                    <span>Total</span>
                                    <span><span id=""TotalAmount"">");
#nullable restore
#line 133 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                                                            Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> VND</span>
                                </div>
                                <div class=""verified-icon"">
                                    <img src=""images/verified.png"">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">

    function PlaceOrder() {
        var RecipientName = $(""#RecipientName"").val();
        var PhoneNumber = $(""#PhoneNumber"").val();
        var Address = $(""#Address"").val();

        var userId = $(""li[name=userAccount]"").attr(""data-content"");
        var totalAmount = parseInt($(""#TotalAmount"").text());
        var shippingFee = parseInt($(""#ShippingFee"").text());
        var status = ""Wait for confirmation"";
        var PaymentMethod = """";

        var payment = $('input[name=paymentSelecting]:checked', '#paymentChoice').val();
        if (payment == ""momo"")");
            WriteLiteral(@" {
            PaymentMethod = ""MoMo Wallet"";

        } else if (payment == ""card"") {
            PaymentMethod = ""Napas ATM/Internet Banking"";

        } else {
            PaymentMethod = ""Cash on delivery (COD)"";
        }


        if (RecipientName === """" || PhoneNumber === """" || Address === """") {
            alert(""Vui lòng nhập đầy đủ thông tin giao hàng!"");
        }
        else {
            
            $.ajax({
                async: true,
                type: 'POST',
                data: {
                    userId: userId,
                    RecipientName: RecipientName,
                    PhoneNumber: PhoneNumber,
                    Address: Address,
                    totalAmount: totalAmount,
                    shippingFee: shippingFee,
                    status: status,
                    PaymentMethod: PaymentMethod
                },
                dataType: ""text"",
                url: '/Ordering/PlaceOrder',
                success: function (da");
            WriteLiteral(@"ta) {
                    const obj = JSON.parse(data);

                    if (obj.success == true) {
                        $(""#cartCount"").text(0);
                        Announcement();
                    }
                },
                error: function () {
                    console.log(""error"")
                }
            })
        }
    }

    function Announcement() {

        var MessagePayment = `
        <section class=""page-wrapper success-msg"">
          <div class=""container"">
            <div class=""row"">
              <div class=""col-md-6 col-md-offset-3"">
                <div class=""block text-center"">
        	        <i class=""tf-ion-android-checkmark-circle""></i>
                  <h2 class=""text-center"">Thank you! For your payment</h2>
                  <p>The seller will contact you in a few minutes.</p>
                  <a href=""");
#nullable restore
#line 218 "C:\NashSneaker\ASP.NET Core\Views\Ordering\Index.cshtml"
                      Write(Url.Action("Index", "Shopping", new { categoryName = "All Shoes" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""btn btn-main mt-20"">Continue Shopping</a>
                </div>
              </div>
            </div>
          </div>
        </section>`;

        $(""#checkoutPage"").replaceWith($(MessagePayment));
    }

    $('#paymentChoice input').on('change', function () {

        console.log(""aloo"")

        var card = `
        <div id=""cardPayment_info"" style=""margin-left: 67px; padding-bottom: 20px;"">
            <div style=""font-size: 15px; font-weight: bold;"">Techcombank</div>
            <div><b>Owner:</b> NGUYEN CHI THANH</div>
            <div><b>Account Number:</b> 1900123456789</div>
            <div><b>Content:</b> Username + Full Name + Phone Number</div>
        </div>`;

        var momo = `
        <div id=""momoPayment_info"" style=""margin-left: 67px; padding-bottom: 20px;"">
            <div style=""font-size: 15px; font-weight: bold;"">MoMo Wallet</div>
            <div><b>Owner:</b> NGUYEN CHI THANH</div>
            <div><b>Phone Number:</b> 0123456789</div>
     ");
            WriteLiteral(@"       <div><b>Content:</b> Username + Full Name + Phone Number</div>
        </div>`;

        var payment = $('input[name=paymentSelecting]:checked', '#paymentChoice').val();

        $(""#cardPayment_info"").remove();
        $(""#momoPayment_info"").remove();

        if (payment == ""card"") {
            $(""#cardPayment"").append($(card));

        } else if (payment == ""momo"") {
            $(""#momoPayment"").append($(momo));
        }
    });
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