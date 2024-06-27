namespace Coffee_Shop.ViewModels
{
    public partial class HotDrinkViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        // Constructor: Initializes HotDrinkViewModel with ProductService dependency injection
        public HotDrinkViewModel(ProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>(_productService.GetHotDrinkCategory());
        }

        // ObservableCollection to hold the list of hot drink category products
        public ObservableCollection<Product> Products { get; set; }

        // Command to navigate to the DetailPage for the selected product
        [RelayCommand]
        private async Task GoToDetailPage(Product product)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailViewModel.Product)] = product
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
