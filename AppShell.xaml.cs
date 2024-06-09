using parcial2.Pages;

namespace parcial2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        }
    }
}
