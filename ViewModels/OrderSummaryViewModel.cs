namespace Coffee_Shop.ViewModels
{
    [QueryProperty(nameof(Order), nameof(Order))]
    public partial class OrderSummaryViewModel : ObservableObject
    {
        // Events for cart item removal and cart cleared
        public event EventHandler<Product> CartItemRemoved;
        public event EventHandler CartCleared;

        // ObservableCollection to hold orders
        public ObservableCollection<Order> Orders { get; set; }

        // Observable properties for customer name, phone, and total amount
        [ObservableProperty]
        private string _customerName;
        [ObservableProperty]
        private string _customerPhone;
        [ObservableProperty]
        private double _totalAmount;

        // ObservableCollection to hold items
        public ObservableCollection<Product> Items { get; set; } = new();

        // Observable property for current order
        [ObservableProperty]
        private Order _order;

        // Method to fetch daily orders from JSON file
        public static ICollection<Order> DailyOrder()
        {
            var orders = new List<Order>();
            try
            {
                // Retrieve the path for public documents folder
                string publicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                // Combine path with file name
                string filePath = Path.Combine(publicPath, "Orders.json");
                // Read JSON data from file
                var jsonData = File.ReadAllText(filePath);
                // Deserialize JSON into a list of Order objects
                var orderList = JsonConvert.DeserializeObject<List<Order>>(jsonData);

                // Filter orders for today's date
                foreach (var order in orderList)
                {
                    if (order.OrderDate == DateTime.Now.ToString("dd/MM/yy"))
                    {
                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error toast if file read fails
                Toast.Make($"Error: {ex.Message}", ToastDuration.Short).Show();
            }

            return orders;
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
                // Display confirmation dialog before removing item
                if (await Shell.Current.DisplayAlert("Delete Item", $"Do you want to delete {item.Name} ?", "Yes", "NO"))
                {
                    Items.Remove(item);
                    RecalculateTotalAmount();
                    // Invoke CartItemRemoved event
                    CartItemRemoved?.Invoke(this, item);
                    await Toast.Make($"{item.Name} has been removed from cart", ToastDuration.Short).Show();
                }
            }
        }

        // Command to clear all items from the cart
        [RelayCommand]
        private async Task ClearCart()
        {
            // Display confirmation dialog before clearing cart
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you want to clear  the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                // Invoke CartCleared event
                CartCleared?.Invoke(this, EventArgs.Empty);
                await Toast.Make("Cart has been cleared", ToastDuration.Short).Show();
            }
        }

        // Command to retrieve and navigate to daily orders page
        [RelayCommand]
        private async Task GetDailyOrders()
        {
            var orders = OrderSummaryViewModel.DailyOrder();
            if (orders is null)
            {
                // Display toast if no orders for today
                await Toast.Make("No orders yet today", ToastDuration.Short).Show();
            }
            else
            {
                // Navigate to DailyOrder page
                await Shell.Current.GoToAsync(nameof(DailyOrder), animate: true);
            }
        }

        // Command to navigate to checkout page
        [RelayCommand]
        private async Task CheckOut()
        {
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }

        // Method to recalculate total amount based on items in cart
        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);
    }
}
