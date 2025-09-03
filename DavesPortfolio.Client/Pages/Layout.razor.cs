namespace DavesPortfolio.Client.Pages
{
    public partial class Layout
    {
        public record Load(string name, string position);
        public IEnumerable<Load> loadout;

        protected override void OnInitialized()
        {
            loadout = new List<Load>
            {
                new Load("Weapon_1", "station_5"),
                new Load("Weapon_2", "station_4"),
                new Load("Weapon_3", "station_3"),
                new Load("Weapon_4", "station_2"),
                new Load("Weapon_5", "station_1"),

            };
        }
    }
}