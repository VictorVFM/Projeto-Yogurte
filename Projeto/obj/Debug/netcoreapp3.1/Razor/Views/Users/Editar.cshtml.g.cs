#pragma checksum "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8522fce4d1bf85e8735674968059bcd57a1a88bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Editar), @"mvc.1.0.view", @"/Views/Users/Editar.cshtml")]
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
#line 1 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\_ViewImports.cshtml"
using Projeto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\_ViewImports.cshtml"
using Projeto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8522fce4d1bf85e8735674968059bcd57a1a88bb", @"/Views/Users/Editar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4dfd97469170fe8b85a6370378ea67b5320a14", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Editar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Projeto.Users>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/editar-usuario.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/footer.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
  
    ViewData["Title"] = "Editar";

    Users user = JsonConvert.DeserializeObject<Users>(Context.Session.GetString("user"));

    IEnumerable<Users> dados = ViewData["dados"] as IEnumerable<Users>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8522fce4d1bf85e8735674968059bcd57a1a88bb6206", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8522fce4d1bf85e8735674968059bcd57a1a88bb7321", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8522fce4d1bf85e8735674968059bcd57a1a88bb8436", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""https://kit.fontawesome.com/15068104d6.js"" crossorigin=""anonymous""></script>


<!-- Required meta tags -->
<meta charset=""utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">

<!-- Bootstrap CSS -->
<link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"">
<div id=""mae-tela"">
<div class=""tela-cadastro"">

    

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8522fce4d1bf85e8735674968059bcd57a1a88bb10092", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 33 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
         foreach (var item in dados)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <input type=\"hidden\" name=\"id\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 1114, "\"", 1137, 1);
#nullable restore
#line 35 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 1122, TempData["id"], 1122, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
                WriteLiteral("            <h1>Editar Usu??rio</h1>\r\n");
#nullable restore
#line 39 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
             if (user.Tipo == "adm")
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <div>\r\n                    <p>Tipo Usu??rio:</p>\r\n                    <input type=\"text\" name=\"tipo\"");
                BeginWriteAttribute("value", " value=\"", 1354, "\"", 1372, 1);
#nullable restore
#line 44 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 1362, item.Tipo, 1362, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"nome\" required>\r\n                </div>\r\n");
                WriteLiteral("                <div>\r\n                    <p>Status Usu??rio:</p>\r\n                    <input type=\"text\" name=\"status\"");
                BeginWriteAttribute("value", " value=\"", 1540, "\"", 1560, 1);
#nullable restore
#line 49 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 1548, item.Status, 1548, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"nome\" required>\r\n                </div>\r\n");
#nullable restore
#line 51 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div>\r\n                <p>Nome Completo:</p>\r\n                <input type=\"text\" name=\"nomeCompleto\"");
                BeginWriteAttribute("value", " value=\"", 1738, "\"", 1764, 1);
#nullable restore
#line 56 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 1746, item.NomeCompleto, 1746, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"nome\" required>\r\n            </div>\r\n");
                WriteLiteral("            <div>\r\n                <p>E-mail:</p>\r\n                <input type=\"email\" name=\"email\"");
                BeginWriteAttribute("value", " value=\"", 1908, "\"", 1927, 1);
#nullable restore
#line 61 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 1916, item.Email, 1916, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"nome\" disabled>\r\n            </div>\r\n");
                WriteLiteral("            <div>\r\n                <p>Senha:</p>\r\n                <input type=\"password\" name=\"senha\"");
                BeginWriteAttribute("value", " value=\"", 2073, "\"", 2092, 1);
#nullable restore
#line 66 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 2081, item.Senha, 2081, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"nome\" required>\r\n            </div>\r\n");
                WriteLiteral("            <div>\r\n                <p>Telefone:</p>\r\n                <input type=\"text\" name=\"telefone\" id=\"telefone\" maxlength=\"12\"");
                BeginWriteAttribute("value", " value=\"", 2269, "\"", 2291, 1);
#nullable restore
#line 71 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 2277, item.Telefone, 2277, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n            </div>\r\n");
                WriteLiteral("            <div>\r\n                <p>Endere??o:</p>\r\n                <input type=\"text\" name=\"endereco\" id=\"endereco\"");
                BeginWriteAttribute("value", " value=\"", 2443, "\"", 2465, 1);
#nullable restore
#line 76 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
WriteAttributeValue("", 2451, item.Endereco, 2451, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" required>\r\n            </div>\r\n            <p>");
#nullable restore
#line 78 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
          Write(TempData["msg"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            <div class=\"button\">\r\n                <button type=\"submit\" id=\"enviar\">Salvar</button>\r\n                <button>");
#nullable restore
#line 81 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
                   Write(Html.ActionLink("Deletar", "Inativar", new { id = item.Email }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n            </div>\r\n");
#nullable restore
#line 83 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 90 "F:\Senai\2DSB\PWFE\OneDrive_2022-06-08 (2)\OneDrive_2022-06-08\_PROJETO DE SEMESTRE\Projeto\Projeto\Views\Users\Editar.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Projeto.Users> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
