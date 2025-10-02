namespace DavesPortfolio.Client.DTOs
{
    public record CrimeRecord(
        string? category,
        string? location_type,
        string? location,
        string? context,
        OutcomeStatus? outcome_status,
        string? persistent_id,
        long? id,
        string? location_subtype,
        string? month
    );

}