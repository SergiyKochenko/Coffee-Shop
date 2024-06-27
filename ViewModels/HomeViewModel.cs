namespace Coffee_Shop.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly ProductService _productService;

        // Constructor: Initializes HomeViewModel with ProductService dependency injection
        public HomeViewModel(ProductService productService)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>(_productService.GetPopularProducts());
        }

        // ObservableCollection to hold the list of popular products
        public ObservableCollection<Product> Products { get; set; }

        // Command to navigate to the AllProductPage and fetch all products
        [RelayCommand]
        private async Task GoToAllProducts()
        {
            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
            await Shell.Current.GoToAsync(nameof(AllProductPage), animate: true);
        }

        // Command to navigate to the FoodPage and fetch food category products
        [RelayCommand]
        private async Task GoToFoodCategory()
        {
            Products = new ObservableCollection<Product>(_productService.GetFoodCategory());
            await Shell.Current.GoToAsync(nameof(FoodPage), animate: true);
        }

        // Command to navigate to the HotDrinkPage and fetch hot drink category products
        [RelayCommand]
        private async Task GoToHotDrinkCategory()
        {
            Products = new ObservableCollection<Product>(_productService.GetHotDrinkCategory());
            await Shell.Current.GoToAsync(nameof(HotDrinkPage), animate: true);
        }

        // Command to navigate to the ColdDrinkPage and fetch cold drink category products
        [RelayCommand]
        private async Task GoToColdDrinkCategory()
        {
            Products = new ObservableCollection<Product>(_productService.GetColdDrinkCategory());
            await Shell.Current.GoToAsync(nameof(ColdDrinkPage), animate: true);
        }

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
