using LeafletForBlazor;

namespace DavesPortfolio.Client.Components
{
    public partial class Mappingbase
    {
        RealTimeMap.LoadParameters parameters = new RealTimeMap.LoadParameters()
        {
            location = new RealTimeMap.Location()
            {
                latitude = 51.5074,
                longitude = -0.1278
            },
            zoomLevel = 13
        };
    }
}