#pragma checksum "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e08b4634253691a5696eca6c27e58e78325ad486"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\_Imports.razor"
using SharedLibrary.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Products</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This is a list of products</p>");
#nullable restore
#line 8 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
 if (products == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p>No products found</p>");
#nullable restore
#line 11 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "ul");
#nullable restore
#line 15 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
         foreach(var product in products)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "li");
            __builder.AddContent(5, "#");
            __builder.AddContent(6, 
#nullable restore
#line 17 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
              product.Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(7, ", ");
            __builder.AddContent(8, 
#nullable restore
#line 17 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
                           product.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 18 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 20 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "C:\Users\Samuel\OneDrive\Skrivbord\Aspnet WebApi\Lektion 4\repetition\WebApiWithKey\BlazorApp\Pages\Index.razor"
       
    private IEnumerable<Product> products;

    protected override async Task OnInitializedAsync()
    {
        products = await Http.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:44322/api/products?AccessKey=703d413bce0f415f9a14cb359be433b6==");
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
