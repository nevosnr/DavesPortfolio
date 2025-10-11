namespace DavesPortfolio.Client.Layout
{
    public partial class MainLayout
    {
        private bool _isDrawerOpen = false;

        public void ToggleDrawer()
        {
            _isDrawerOpen = !_isDrawerOpen;
        }
    }
}