// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PWA.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using AntDesign.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using IndexedDB.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using PWA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using PWA.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using PWA.Shared.Componets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using PWA.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\_Imports.razor"
using Tools;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
 
    EmbeddedProperty Property(int span, int offset) => new() { Span = span, Offset = offset };

    RenderFragment titleGenerator =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(0, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        出题\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 74 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment titleSetting =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(1, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        设置\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 80 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment titleExercise =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(2, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        自测\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 86 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment titleWrongs =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(3, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        错题集\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 92 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment titleStatist =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(4, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        统计\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 98 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment titleAbout =
    

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(5, "<AntDesign.Title Level=\"4\" Style=\"display:table;margin:0 auto;color:#4d4030\">\r\n        关于\r\n    </AntDesign.Title>");
        }
#nullable restore
#line 104 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                      ;

    RenderFragment coverGenerator = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(6, "<img alt=\"出题\" src=\"src/Generator.png\">");
        }
#nullable restore
#line 106 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                             ;

    RenderFragment coverSetting = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(7, "<img alt=\"设置\" src=\"src/Setting.png\">");
        }
#nullable restore
#line 108 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                         ;

    RenderFragment coverExercise = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(8, "<img alt=\"自测\" src=\"src/Exercise.png\">");
        }
#nullable restore
#line 110 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                           ;

    RenderFragment coverWrongs = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(9, "<img alt=\"错题集\" src=\"src/Wrongs.png\">");
        }
#nullable restore
#line 112 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                        ;

    RenderFragment coverStatist = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(10, "<img alt=\"统计\" src=\"src/Statist.png\">");
        }
#nullable restore
#line 114 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                         ;

    RenderFragment coverAbout = 

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(11, "<img alt=\"关于\" src=\"src/About.png\">");
        }
#nullable restore
#line 116 "E:\TeamProgramming\TeamProgramming-ExercisesGenerator\ExercisesGenerator\PWA\Pages\Index.razor"
                                                                     ;

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591