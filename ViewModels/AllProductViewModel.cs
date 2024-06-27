namespace Coffee_Shop.ViewModels
{
    public partial class AllProductViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        // Constructor: Initializes the view model with ProductService dependency injection
        public AllProductViewModel(ProductService productService)
        {
            _productService = productService;

            // Initializes ObservableCollection with all products from ProductService
            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
        }

        // Property: ObservableCollection of products bound to the UI
        public ObservableCollection<Product> Products { get; set; }

        // Property: Indicates if a search operation is in progress
        [ObservableProperty]
        private bool _searching;

        // Command Method: Executes a search for products based on search text
        [RelayCommand]
        private async Task SearchProducts(string searchText)
        {
            Products.Clear(); // Clears existing products in the ObservableCollection
            Searching = true; // Sets _searching flag to true, indicating search is ongoing

            await Task.Delay(1000); // Simulates a delay (e.g., network request or processing time)

            // Retrieves products matching the search text from ProductService and adds them to Products collection
            foreach (var product in _productService.GetProducts(searchText))
            {
                Products.Add(product);
            }

            Searching = false; // Sets _searching flag to false, indicating search is complete
        }

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
