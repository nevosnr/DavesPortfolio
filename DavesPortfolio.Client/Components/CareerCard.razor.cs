using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DavesPortfolio.Client.Components
{
    public partial class CareerCard
    {
        [Inject] IDialogService DialogService { get; set; } = default!;
        private async Task ViewJob()
        {
            var parameters = new DialogParameters
            {

            };
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            await DialogService.ShowAsync<CareerDialogue>(_careerJobTitle, parameters, options);
        }

        [Parameter] public string? _careerIcon { get; set; } = Icons.Material.Filled.Info;
        [Parameter] public string? _careerJobTitle { get; set; } = "<<JOB_TITLE>>";
        [Parameter] public string? _careerRoleTitle { get; set; } = "<<ROLE_TITLE>>";
        [Parameter] public string? _careerShortDescription { get; set; } = "<<SHORT_DESCRIP>>";

    }
}