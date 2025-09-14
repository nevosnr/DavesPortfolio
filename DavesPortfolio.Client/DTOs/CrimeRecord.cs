namespace DavesPortfolio.Client.DTOs
{
    public record CrimeRecord(
        string category,
        string locationType,
        Location location,
        string outcomeStatus,
        string persistentId,
        string id,
        string month
    );

}
