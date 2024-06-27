namespace Coffee_Shop.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class DetailViewModel : ObservableObject, IDisposable
    {
        private readonly OrderViewModel _orderViewModel;

        // Constructor: Initializes DetailViewModel with OrderViewModel and subscribes to its events
        public DetailViewModel(OrderViewModel orderViewModel)
        {
            _orderViewModel = orderViewModel;
            _orderViewModel.CartCleared += OnCartCleared;
            _orderViewModel.CartItemRemoved += OnCartItemRemoved;
            _orderViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        // Observable property for the selected product
        [ObservableProperty]
        private Product _product;

        // Event handler for when the cart is cleared
        private void OnCartCleared(Object? _, EventArgs e) => Product.CartQuantity = 0;

        // Event handler for when a cart item is updated
        private void OnCartItemUpdated(Object? _, Product p) => OnCartItemChanged(p, p.CartQuantity);

        // Event handler for when a cart item is removed
        private void OnCartItemRemoved(Object? _, Product p) => OnCartItemChanged(p, 0);

        // Method to update the cart quantity of the current product
        private void OnCartItemChanged(Product p, int quantity)
        {
            if (p.Name == Product.Name)
            {
                Product.CartQuantity = quantity;
            }
        }

        // Command to add the current product to the cart
        [RelayCommand]
        private void AddToCart()
        {
            Product.CartQuantity++;
            _orderViewModel.UpdateCartCommand.Execute(Product);
        }

        // Command to remove the current product from the cart
        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Product.CartQuantity > 0)
            {
                Product.CartQuantity--;
                _orderViewModel.UpdateCartCommand.Execute(Product);
            }
        }

        // Command to navigate to the OrderPage to view the cart
        [RelayCommand]
        private async Task ViewCart()
        {
            if (Product.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(OrderPage), animate: true);
            }
            else
            {
                await Toast.Make("Please use the plus sign button to add item to your cart", ToastDuration.Short).Show();
            }
        }

        // Implementation of IDisposable interface to unsubscribe from events
        public void Dispose()
        {
            _orderViewModel.CartCleared -= OnCartCleared;
            _orderViewModel.CartItemRemoved -= OnCartItemRemoved;
            _orderViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}
