#pragma checksum "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74f6cae55e4233201d7c4c571aed791c6c1ca372"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WeddingInfo), @"mvc.1.0.view", @"/Views/Home/WeddingInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/WeddingInfo.cshtml", typeof(AspNetCore.Views_Home_WeddingInfo))]
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
#line 1 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/_ViewImports.cshtml"
using WeddingPlannerRadhin;

#line default
#line hidden
#line 2 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/_ViewImports.cshtml"
using WeddingPlannerRadhin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74f6cae55e4233201d7c4c571aed791c6c1ca372", @"/Views/Home/WeddingInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ded2c80330f3ee0a4664eb250b536f949a2f248c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WeddingInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 19, true);
            WriteLiteral("<h1>Activity Name: ");
            EndContext();
            BeginContext(20, 21, false);
#line 1 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
              Write(ViewBag.wedding.Groom);

#line default
#line hidden
            EndContext();
            BeginContext(41, 34, true);
            WriteLiteral("</h1>\n\n<p align=\"right\"><button><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 75, "\"", 111, 2);
            WriteAttributeValue("", 82, "/account/", 82, 9, true);
#line 3 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
WriteAttributeValue("", 91, ViewBag.User.UserId, 91, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(112, 51, true);
            WriteLiteral(">Dashboard</a></button></p>\n\n<p>Event Coordinator: ");
            EndContext();
            BeginContext(164, 21, false);
#line 5 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
                 Write(ViewBag.wedding.Bride);

#line default
#line hidden
            EndContext();
            BeginContext(185, 21, true);
            WriteLiteral("</p>\n<p>Description: ");
            EndContext();
            BeginContext(207, 23, false);
#line 6 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
           Write(ViewBag.wedding.Address);

#line default
#line hidden
            EndContext();
            BeginContext(230, 421, true);
            WriteLiteral(@"</p>
<h3>List of Participants:</h3>

<style>
    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
        width: 100%;
    }

    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }
</style>

<table>
    <tr>
        <th>First Name</th>
        <th>Last Name</th>
    </tr>
");
            EndContext();
#line 32 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
     foreach(var guest in ViewBag.wedding.listOfGuests)
    {

#line default
#line hidden
            BeginContext(713, 21, true);
            WriteLiteral("    <tr>\n        <td>");
            EndContext();
            BeginContext(735, 20, false);
#line 35 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
       Write(guest.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(755, 18, true);
            WriteLiteral("</td>\n        <td>");
            EndContext();
            BeginContext(774, 19, false);
#line 36 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
       Write(guest.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(793, 16, true);
            WriteLiteral("</td>\n    </tr>\n");
            EndContext();
#line 38 "/Users/haritsdanoesoebroto/Desktop/WeddingPlannerRadhin/WeddingPlannerRadhin/Views/Home/WeddingInfo.cshtml"
    }

#line default
#line hidden
            BeginContext(815, 76, true);
            WriteLiteral("</table>\n\n<p align=\"right\"><button><a href=\"/logout\">Logout</a></button></p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
