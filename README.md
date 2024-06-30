# Coffee Shop Application
## Overview
The Coffee Shop application is a comprehensive system designed to manage coffee shop orders, products, and customer interactions. It consists of several models and view models that facilitate order processing, product management, and navigation within the application. This README provides a detailed guide on the functionality and structure of the application.

### Table of Contents
1. Models
- Order
- Product
2. ViewModels
- AllProductViewModel
- ColdDrinkViewModel
- DailyOrderViewModel
- DetailViewModel
- FoodViewModel
- HomeViewModel
- HotDrinkViewModel
- OrderSummaryViewModel
- OrderViewModel
3. Commands
Models
## Order
The Order class represents an order in the coffee shop.

### Properties:

- IEnumerable<Product> CartItems: The list of products in the order.
- string CustomerName: The name of the customer.
- string CustomerPhone: The customer's phone number.
- string OrderNumber: The unique order number.
- string OrderDate: The date of the order.
- double TotalAmount: The total amount of the order (computed).
### Methods:

- Order(IEnumerable<Product> products, string customerName, string customerPhone, string orderNumber, string orderDate): Constructor to initialize an order with provided data.
- Order(): Empty constructor for creating an empty order.
double CalculateTotalAmount(): Private method to calculate the total amount based on CartItems.
- Order Clone(): Method to clone the current order.
## Product
The Product class represents a product in the coffee shop.

### Properties:

- string Name: The name of the product.
- string Category: The category of the product.
- string Image: The image URL of the product.
- double Price: The price of the product.
- string Description: The description of the product.
- int CartQuantity: The quantity of the product in the cart.
- double Amount: The total amount for the product based on price and quantity (computed).
### Methods:

- override string ToString(): Custom string representation of the product.
- Product Clone(): Method to create a shallow copy of the product.
## ViewModels
### AllProductViewModel
Manages all products in the coffee shop.

### Constructor:

- AllProductViewModel(ProductService productService): Initializes the view model with a ProductService dependency.
### Properties:

ObservableCollection<Product> Products: Collection of all products.
bool Searching: Indicates if a search operation is in progress.
### Methods:

- Task SearchProducts(string searchText): Searches for products based on the search text.
- Task GoToDetailPage(Product product): Navigates to the detail page for a specific product.
ColdDrinkViewModel
## Manages cold drink products.

### Constructor:

- ColdDrinkViewModel(ProductService productService): Initializes the view model with a ProductService dependency.
### Properties:

- ObservableCollection<Product> Products: Collection of cold drink products.
## Methods:

- Task GoToDetailPage(Product product): Navigates to the detail page for a specific product.
## DailyOrderViewModel
Manages daily orders.

### Constructor:

- DailyOrderViewModel(OrderSummaryViewModel orderSummaryView): Initializes the view model with an OrderSummaryViewModel dependency.
### Properties:

- string CustomerName
- string CustomerPhone
- double TotalAmount
- ObservableCollection<Product> Items: Items in the daily order.
- Order Order
- ICollection<Order> Orders: Collection of orders.
## DetailViewModel
Manages the details of a specific product and interactions with the shopping cart.

### Constructor:

- DetailViewModel(OrderViewModel orderViewModel): Initializes the view model with an OrderViewModel dependency.
## Properties:

- Product Product: The selected product.
### Methods:

- void AddToCart(): Adds the product to the cart.
- void RemoveFromCart(): Removes the product from the cart.
- Task ViewCart(): Navigates to the order page to view the cart.
## FoodViewModel
Manages food products.

### Constructor:

- FoodViewModel(ProductService productService): Initializes the view model with a ProductService dependency.
### Properties:

- ObservableCollection<Product> Products: Collection of food products.
### Methods:

- Task GoToDetailPage(Product product): Navigates to the detail page for a specific product.
## HomeViewModel
Manages popular products and navigation to different product categories.

### Constructor:

- HomeViewModel(ProductService productService): Initializes the view model with a ProductService dependency.
### Properties:

- ObservableCollection<Product> Products: Collection of popular products.
### Methods:

- Task GoToAllProducts(): Navigates to the all products page.
- Task GoToFoodCategory(): Navigates to the food category page.
- Task GoToHotDrinkCategory(): Navigates to the hot drink category page.
- Task GoToColdDrinkCategory(): Navigates to the cold drink category page.
- Task GoToDetailPage(Product product): Navigates to the detail page for a specific product.
## HotDrinkViewModel
Manages hot drink products.

### Constructor:

- HotDrinkViewModel(ProductService productService): Initializes the view model with a ProductService dependency.
### Properties:

- ObservableCollection<Product> Products: Collection of hot drink products.
### Methods:

- Task GoToDetailPage(Product product): Navigates to the detail page for a specific product.
## OrderSummaryViewModel
Manages the order summary, including cart operations.

### Properties:

- ObservableCollection<Order> Orders
- string CustomerName
- string CustomerPhone
- double TotalAmount
- ObservableCollection<Product> Items
- Order Order
### Events:

- EventHandler<Product> CartItemRemoved
- EventHandler CartCleared
### Methods:

- ICollection<Order> DailyOrder(): Fetches daily orders from a JSON file.
- void UpdateCart(Product product): Updates the shopping cart with a product.
- Task RemoveCartItem(string name): Removes a specific item from the cart.
- Task ClearCart(): Clears all items from the cart.
- Task GetDailyOrders(): Retrieves and navigates to daily orders page.
- Task CheckOut(): Navigates to the checkout page.
## OrderViewModel
Manages the order process, including cart operations and customer details.

### Properties:

- ObservableCollection<Product> Items
- ObservableCollection<Order> Orders
- string CustomerName
- string CustomerPhone
- double TotalAmount
### Events:

- EventHandler<Product> CartItemRemoved
- EventHandler<Product> CartItemUpdated
- EventHandler CartCleared
- EventHandler EmptyCart
### Methods:

- Order GetOrder(): Creates and returns an order object based on the current cart state and customer details.
- void UpdateCart(Product product): Updates the shopping cart with a product.
- Task RemoveCartItem(string name): Removes a specific item from the cart.
- Task CartEmpty(): Empties the entire cart.
- Task ClearCart(): Clears all items from the cart.
## Commands
Commands in the view models facilitate interaction between the user interface and the underlying logic. Each command corresponds to a specific action, such as searching for products, adding items to the cart, navigating to different pages, etc.

### Examples of commands:

- RelayCommand SearchProducts(string searchText)
- RelayCommand GoToDetailPage(Product product)
- RelayCommand AddToCart()
- RelayCommand RemoveFromCart()
- RelayCommand ViewCart()
- RelayCommand ClearCart()
- RelayCommand GetDailyOrders()
- RelayCommand CheckOut()
