using DavesPortfolio.Client.DTOs;
using DavesPortfolio.Client.Services;
using Microsoft.AspNetCore.Components;

namespace DavesPortfolio.Client.Pages
{
    public partial class Richweb1b : ComponentBase
    {
        string _selectedForce;
        List<Polforceloc> _policeForces = new();

        [Inject] PoliceDataService PoliceDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _policeForces = await PoliceDataService.GetForcesAsync();
        }
    }
}