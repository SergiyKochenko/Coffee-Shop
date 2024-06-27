namespace Coffee_Shop.Models
{
    public partial class Order : ObservableObject
    {
        // Properties representing an order
        public IEnumerable<Product> CartItems { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }

        // Computed property to calculate total amount of the order
        public double TotalAmount => CalculateTotalAmount();

        // Constructor to initialize an Order object with provided data
        public Order(IEnumerable<Product> products, string customerName, string customerPhone, string orderNumber, string orderDate)
        {
            CartItems = products;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        // Empty constructor for creating an empty Order object
        public Order()
        {

        }

        // Private method to calculate the total amount based on CartItems
        private double CalculateTotalAmount()
        {
            if (CartItems == null)
                return 0;

            return CartItems.Sum(product => product.Amount);
        }

        // Method to clone the current Order object
        public Order Clone() => MemberwiseClone() as Order;
    }
}
