namespace DavesPortfolio.Client.DTOs
{
    public record CrimeRecord(
        string category,
        string location_type,
        Location location,
        string outcome_status,
        string persistent_id,
        string id,
        string month
    );

}


//{
//        "category": "burglary", 
//        "persistent_id": "5e9de2c5b7cdfe4f95f13adbd973dbb175ad6de7dcaf2cbcbe1cfec98cd783cf", 
//        "location_subtype": "", 
//        "id": 116205510, 
//        "location": null, 
//        "context": "", 
//        "month": "2024-01", 
//        "location_type": null, 
//        "outcome_status": {
//            "category": "Investigation complete; no suspect identified", 
//            "date": "2024-01"
//        }