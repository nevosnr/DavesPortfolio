using DavesPortfolio.Client.DTOs;
using DavesPortfolio.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DavesPortfolio.Client.Pages
{
    public partial class Richweb1B : ComponentBase
    {
        string _selectedForce;
        string _selectedCategory;
        string _selectedNeighbourhood;
        bool _isHydrated = false;
        List<Polforceloc> _policeForces = new();
        List<CrimeCategories> _crimeCategories = new();
        List<Neighbourhood> _neighbourhoods = new();
        List<Latlng> _boundary = new();
        [Inject] PoliceDataService PoliceDataService { get; set; }
        [Inject] IJSRuntime JS { get; set; }
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

        private string SelectedNeighbourhood
        {
            get => _selectedNeighbourhood;
            set
            {
                if (_selectedNeighbourhood != value)
                {
                    _selectedNeighbourhood = value;
                    _ = OnNeighbourhoodChanged(_selectedForce, value);
                }
            }
        }

        private string SelectedCrime
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    _ = OnCatChange(value);
                }
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && OperatingSystem.IsBrowser())
            {
                _isHydrated = true;
                StateHasChanged(); // Trigger a re-render after hydration
            }
        }
        protected override async Task OnInitializedAsync()
        {
            if (!OperatingSystem.IsBrowser()) return;
            _policeForces = await PoliceDataService.GetForcesAsync();
            _crimeCategories = await PoliceDataService.GetCategoriesAsync();

            if (!string.IsNullOrWhiteSpace(_selectedForce))
            {
                _neighbourhoods = await PoliceDataService.GetNeighbourhoodsAsync(_selectedForce);
                if (!string.IsNullOrWhiteSpace(_selectedNeighbourhood))
                {
                    _boundary = await PoliceDataService.GetBoundryAsync(_selectedForce, _selectedNeighbourhood);
                    await JS.InvokeVoidAsync("drawBoundry", "mapId", _boundary);
                }
            }
        }

        private async Task OnForceChanged(string forceId)
        {
            _selectedForce = forceId;
            _neighbourhoods = await PoliceDataService.GetNeighbourhoodsAsync(forceId);
            _selectedNeighbourhood = null; // Reset selected neighbourhood
        }

        private async Task OnNeighbourhoodChanged(string forceId, string nHoodId)
        {
            if (!string.IsNullOrWhiteSpace(nHoodId))
            {
                _boundary = await PoliceDataService.GetBoundryAsync(forceId, nHoodId);
                await JS.InvokeVoidAsync("drawBoundry", "mapId", _boundary);
            }
        }

        private async Task OnCatChange(string category)
        {
            _selectedCategory = category;
            if (_boundary != null && _boundary.Count > 0)
            {
                var crimes = await PoliceDataService.GetCrimesByBoundry(_boundary);
                var filteredCrimes = crimes.Where(c => c.category == category).ToList();
                await JS.InvokeVoidAsync("addMarker", "mapId", filteredCrimes);
            }
        }

        [JSInvokable("OnMarkerClick")]
        public static Task OnMarkerClick(string crimeId)
        {
            return Task.CompletedTask;
        }

    }
}