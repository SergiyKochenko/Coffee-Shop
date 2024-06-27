namespace Coffee_Shop
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
        }
    }
}
