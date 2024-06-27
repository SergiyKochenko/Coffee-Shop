namespace Coffee_Shop.Models
{
    public partial class Product : ObservableObject
    {
        // Properties representing a product
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        // ObservableProperty for tracking changes in CartQuantity
        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        // Computed property to calculate total amount for the product based on Price and CartQuantity
        public double Amount => Price * CartQuantity;

        // Override of ToString method for custom representation of the Product object
        public override string ToString()
        {
            return String.Format("Name:{0}, Price:{1}, Quantity:{2}", this.Name, this.Price, this.CartQuantity);
        }

        // Method to create a shallow copy (clone) of the Product object
        public Product Clone() => MemberwiseClone() as Product;
    }
}
