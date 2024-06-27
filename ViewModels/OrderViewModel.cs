namespace Coffee_Shop.ViewModels
{
    public partial class OrderViewModel : ObservableObject
    {
        // Events for cart item manipulation and cart state changes
        public event EventHandler<Product> CartItemRemoved;
        public event EventHandler<Product> CartItemUpdated;
        public event EventHandler CartCleared;
        public event EventHandler EmptyCart;

        // ObservableCollection to hold items in the shopping cart
        public ObservableCollection<Product> Items { get; set; } = new();

        // Observable properties for orders, customer details, and total amount
        [ObservableProperty]
        private ObservableCollection<Order> _orders;
        [ObservableProperty]
        private string _customerName;
        [ObservableProperty]
        private string _customerPhone;
        [ObservableProperty]
        private double _totalAmount;

        // Reference to OrderSummaryViewModel for coordination
        private readonly OrderSummaryViewModel _orderSummaryViewModel;

        public OrderViewModel(OrderSummaryViewModel orderSummaryViewModel)
        {
            _orderSummaryViewModel = orderSummaryViewModel;
        }

        // Method to recalculate the total amount based on items in the cart
        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        // Method to generate a unique order number
        private static string GenerateOrderNumber()
        {
            return Guid.NewGuid().ToString("N")[..8].ToUpper();
        }

        // Method to retrieve all items in the cart
        private ICollection<Product> GetCartItems()
        {
            var cartItems = new List<Product>();
            foreach (var item in Items)
            {
                cartItems.Add(item);
            }
            return cartItems;
        }

        // Method to create and return an Order object based on current cart state and customer details
        public Order GetOrder()
        {
            var order = new Order(GetCartItems(), CustomerName, CustomerPhone, OrderViewModel.GenerateOrderNumber(), DateTime.Now.ToString("dd/MM/yy"));
            return order;
        }

        // Command to update the shopping cart
        [RelayCommand]
        private void UpdateCart(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Name == product.Name);
            if (item != null)
            {
                item.CartQuantity = product.CartQuantity;
            }
            else
            {
                Items.Add(product.Clone());
            }
            RecalculateTotalAmount();
        }

        // Command to remove a specific item from the cart
        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name.Equals(name));
            if (item is not null)
            {
                // Display confirmation dialog before removing the item
                if (await Shell.Current.DisplayAlert("Delete Item", $"Do you want to delete {item.Name} ?", "YES", "NO"))
                {
                    Items.Remove(item);
                    RecalculateTotalAmount();
                    // Invoke CartItemRemoved event and display toast message
                    CartItemRemoved?.Invoke(this, item);
                    await Toast.Make($"{item.Name} has been removed from cart", ToastDuration.Short).Show();
                }
            }
        }

        // Command to empty the entire cart
        [RelayCommand]
        private async Task CartEmpty()
        {
            Items.Clear();
            CustomerName = null;
            CustomerPhone = null;
            RecalculateTotalAmount();
            // Invoke CartCleared event and display toast message
            CartCleared?.Invoke(this, EventArgs.Empty);
            await Toast.Make("Your order has been submitted", ToastDuration.Short).Show();
        }

        // Command to clear all items from the cart
        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you want to clear  the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                // Invoke CartCleared event and display toast message
                CartCleared?.Invoke(this, EventArgs.Empty);
                await Toast.Make("Cart has been cleared", ToastDuration.Short).Show();
            }
        }
    }
}
