namespace Coffee_Shop.ViewModels
{
    public partial class DailyOrderViewModel : ObservableObject
    {
        // Observable properties for data binding
        [ObservableProperty]
        private string _customerName;
        [ObservableProperty]
        private string _customerPhone;
        [ObservableProperty]
        private double _totalAmount;

        // ObservableCollection to hold items/products in the daily order
        public ObservableCollection<Product> Items { get; set; } = new();

        // Observable property to store the current order details
        [ObservableProperty]
        private Order _order;

        // Collection of orders
        public ICollection<Order> Orders { get; set; }

        // Reference to OrderSummaryViewModel for interaction with daily orders
        private readonly OrderSummaryViewModel _orderSummary;

        // Constructor: Initializes the view model with an instance of OrderSummaryViewModel
        public DailyOrderViewModel(OrderSummaryViewModel orderSummaryView)
        {
            _orderSummary = orderSummaryView;

            // Retrieves daily orders from OrderSummaryViewModel
            Orders = OrderSummaryViewModel.DailyOrder();
        }
    }
}
