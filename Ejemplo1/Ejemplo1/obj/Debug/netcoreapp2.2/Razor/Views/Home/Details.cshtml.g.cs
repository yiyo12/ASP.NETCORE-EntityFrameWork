#pragma checksum "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4932e5f0120dd67f5e96c1064114ab3fa23dbe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Details.cshtml", typeof(AspNetCore.Views_Home_Details))]
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
#line 3 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\_ViewImports.cshtml"
using Ejemplo1.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\_ViewImports.cshtml"
using Ejemplo1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4932e5f0120dd67f5e96c1064114ab3fa23dbe4", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"679aa18a5b1e7b0682ced4596939956291fa41d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetallesView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top imagen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Js/Miscript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 4 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
  
    //Cuando se tiene eun _ViewStart no es necesario especificar en cada vista la ruta
    //Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "Amigos Detalles";
    ///AL tener ?? indica que si no ponemos una foto osea ser == null pondra por defcto noImg.png 

    var rutaImagen = "~/images/" + (Model.amigo.rutaFoto ?? "NoIMG.png");



#line default
#line hidden
            BeginContext(390, 217, true);
            WriteLiteral("\r\n\r\n    <div class=\"row justify-content-center m-3\">\r\n        <div class=\"col-sm-8\">\r\n            \r\n            <div class=\"card\">\r\n                \r\n                <div class=\"card-header\">\r\n                    <h1>");
            EndContext();
            BeginContext(608, 18, false);
#line 22 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
                   Write(Model.amigo.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(626, 106, true);
            WriteLiteral("</h1>\r\n                </div>\r\n                <div class=\"card-body text-center\">\r\n\r\n                    ");
            EndContext();
            BeginContext(732, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b4932e5f0120dd67f5e96c1064114ab3fa23dbe45403", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#line 26 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
                  WriteLiteral(rutaImagen);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 26 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(811, 38, true);
            WriteLiteral("\r\n\r\n                    <h4>Amigo ID: ");
            EndContext();
            BeginContext(850, 14, false);
#line 28 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
                             Write(Model.amigo.Id);

#line default
#line hidden
            EndContext();
            BeginContext(864, 44, true);
            WriteLiteral("</h4>\r\n                    <h4>Amigo Email: ");
            EndContext();
            BeginContext(909, 17, false);
#line 29 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
                                Write(Model.amigo.Email);

#line default
#line hidden
            EndContext();
            BeginContext(926, 45, true);
            WriteLiteral("</h4>\r\n                    <h4>Amigo Ciudad: ");
            EndContext();
            BeginContext(972, 18, false);
#line 30 "C:\Users\yiyos\Desktop\CursoC#\CursoNetCoreYou\Ejemplo1\Ejemplo1\Views\Home\Details.cshtml"
                                 Write(Model.amigo.Ciudad);

#line default
#line hidden
            EndContext();
            BeginContext(990, 385, true);
            WriteLiteral(@"</h4>

                </div>
                <div class=""card-footer  text-center"">
                    <a href=""#"" class=""btn btn-primary"">Ver</a>
                    <a href=""#"" class=""btn btn-primary"">Editar</a>
                    <a href=""#"" class=""btn btn-danger"">Borrar</a>

                </div>
            </div>
        </div>        

    </div>






");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1394, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1400, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4932e5f0120dd67f5e96c1064114ab3fa23dbe49388", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1440, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetallesView> Html { get; private set; }
    }
}
#pragma warning restore 1591
