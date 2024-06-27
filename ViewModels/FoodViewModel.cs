namespace Coffee_Shop.ViewModels
{
    public partial class FoodViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        // Constructor: Initializes FoodViewModel with ProductService dependency injection
        public FoodViewModel(ProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>(_productService.GetFoodCategory());
        }

        // ObservableCollection to hold the list of food products
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
