#pragma checksum "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76357242fa04ca271786f1a8dc95728d5d79410d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(UCP.App.Frontend.Pages.Listas.Pages_Listas_Profesores), @"mvc.1.0.razor-page", @"/Pages/Listas/Profesores.cshtml")]
namespace UCP.App.Frontend.Pages.Listas
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
#line 1 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\_ViewImports.cshtml"
using UCP.App.Frontend;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76357242fa04ca271786f1a8dc95728d5d79410d", @"/Pages/Listas/Profesores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3d4c9d00bb47d29c7c3d5319e146ba2d6a0c360", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Listas_Profesores : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Lista de profesores</h1>\r\n<table>\r\n");
#nullable restore
#line 7 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
     foreach (var profesor in Model.Profesores)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 10 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
           Write(profesor.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 11 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
           Write(profesor.apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 12 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
           Write(profesor.telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 13 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
           Write(profesor.facultad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 14 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
           Write(profesor.cubiculo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 16 "C:\UCParking18\UCP.App\UCP.App.Frontend\Pages\Listas\Profesores.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UCP.APP.Frontend.Pages.ProfesoresModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UCP.APP.Frontend.Pages.ProfesoresModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<UCP.APP.Frontend.Pages.ProfesoresModel>)PageContext?.ViewData;
        public UCP.APP.Frontend.Pages.ProfesoresModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
