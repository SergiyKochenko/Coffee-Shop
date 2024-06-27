namespace Coffee_Shop.ViewModels
{
    public partial class ColdDrinkViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        // Constructor: Initializes the view model with ProductService dependency injection
        public ColdDrinkViewModel(ProductService productService)
        {
            _productService = productService;

            // Initializes ObservableCollection with products from the Cold Drink category fetched from ProductService
            Products = new ObservableCollection<Product>(_productService.GetColdDrinkCategory());
        }

        // Property: ObservableCollection of cold drink products bound to the UI
        public ObservableCollection<Product> Products { get; set; }

        // Command Method: Navigates to the detail page for a specific product
        [RelayCommand]
        private async Task GoToDetailPage(Product product)
        {
            // Prepares navigation parameters to pass the selected product to the detail page
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailViewModel.Product)] = product
            };

            // Navigates to the DetailPage using Shell navigation, passing parameters and animating the transition
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
