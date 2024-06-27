using Newtonsoft.Json;

namespace Coffee_Shop.Views;

public partial class OrderPage : ContentPage
{
    private string _customerName;
    private string _customerPhone;
    private Order _order;
    private readonly OrderViewModel _orderViewModel;

    public string fileName = "Orders.json";

    public OrderPage(OrderViewModel orderViewModel)
	{
        _orderViewModel = orderViewModel;
        InitializeComponent();
		BindingContext = _orderViewModel;
	}

    public async void WriteToFile()
    {
        try
        {
            List<Order> orders = new();
            // Get the public documents folder path
            string publicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

            // Combine the public documents folder path with a file name
            string filePath = Path.Combine(publicPath, "Orders.json");
            //Add current order to list of orders
            orders.Add(_orderViewModel.GetOrder());
            //Serialize the orders list of the customer
            string jsonOrder = JsonConvert.SerializeObject(orders, Formatting.Indented);
            
            //check if file exists in the specified path
            if (File.Exists(filePath) == false)
            {
                //write the json string to a file
                File.WriteAllText(filePath, jsonOrder);
            }
            // read the existing json file
            var jsonData = File.ReadAllText(filePath);
            //Deserialize the json to a list of order objects
            var orderList = JsonConvert.DeserializeObject<List<Order>>(jsonData);
            //add new order to the list of orders
            orderList.Add(_orderViewModel.GetOrder());
            //Serialize the order list back to json
            jsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);
            // Write the JSON data to the file, overwriting the existing content
            File.WriteAllText(filePath, jsonData);

        }
        catch (Exception ex)
        {
           // Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
        }
        
    }

  
    private async void Button_Clicked(object sender, EventArgs e)
    {
        _customerName = CustomerName.Text;
        _customerPhone = PhoneNumber.Text;
        _order = _orderViewModel.GetOrder();
       
        if (_customerName is null && _customerPhone is null && _order.CartItems is not null)
        {
            await Toast.Make("Please enter your details to place an order", ToastDuration.Short).Show();
        }
        else if (!this._order.CartItems.Any() && _customerName is not null && this._customerPhone is not null)
        {
            await Toast.Make("Your cart is empty!!", ToastDuration.Long).Show();
        }
        else
        {
           WriteToFile();
            _orderViewModel.CartEmptyCommand.Execute(this);
           await Shell.Current.DisplayAlert("Message", $"Order successfully saved to file {fileName}", "OK");
           await Shell.Current.GoToAsync(nameof(OrderSummary), new Dictionary<string, object> { ["Order"] = _order});
            
       
        
        }


        }
    }