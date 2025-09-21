using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace DavesPortfolio.Client.Components
{
    public partial class Mappingbase : ComponentBase
    {
        [Parameter] public double Lat { get; set; } = 51.505;
        [Parameter] public double Lng { get; set; } = -0.09;
        [Parameter] public int Zoom { get; set; } = 13;
        [Parameter] public string mapId { get; set; } = $"map-{Guid.NewGuid()}";

        [Inject] IJSRuntime JS { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && JS != null)
            {
                await JS.InvokeVoidAsync("initMap", mapId, Lat, Lng, Zoom);
            }
        }
    }
}