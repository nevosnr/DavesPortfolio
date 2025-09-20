using DavesPortfolio.Client.DTOs;
using DavesPortfolio.Client.Services;
using Microsoft.AspNetCore.Components;

namespace DavesPortfolio.Client.Pages
{
    public partial class Richweb1B : ComponentBase
    {
        string _selectedForce;
        string _selectedCategory;
        string _selectedNeighbourhood;
        List<Polforceloc> _policeForces = new();
        List<CrimeCategories> _crimeCategories = new();
        List<Neighbourhood> _neighbourhoods = new();
        private string SelectedForce
        {
            get => _selectedForce;
            set
            {
                if (_selectedForce != value)
                {
                    _selectedForce = value;
                    _ = OnForceChanged(value);
                }
            }
        }

        [Inject] PoliceDataService PoliceDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _policeForces = await PoliceDataService.GetForcesAsync();
            _crimeCategories = await PoliceDataService.GetCategoriesAsync();
        }

        private async Task OnForceChanged(string forceId)
        {
            _selectedForce = forceId;
            _neighbourhoods = await PoliceDataService.GetNeighbourhoodsAsync(forceId);
            _selectedNeighbourhood = null; // Reset selected neighbourhood
        }

    }
}