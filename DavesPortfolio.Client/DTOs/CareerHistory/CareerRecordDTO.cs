using Microsoft.AspNetCore.Components;

namespace DavesPortfolio.Client.DTOs.CareerHistory
{
    public record CareerRecordDTO
    (
        int _Id,
        string? _careerIcon,
        string? _careerJobTitle,
        string? _careerRoleTitle,
        string? _careerShortDescription,
        string? _careerLongDescription,
        DateTime _careerStartDate,
        DateTime? _careerEndDate
    );
}