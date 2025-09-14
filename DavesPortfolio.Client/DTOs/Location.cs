namespace DavesPortfolio.Client.DTOs
{
    public record Location
    (
        string longitude,
        string latitude,
        Street street
    );
}
