namespace Coffee_Shop.Views;

public partial class AllProductPage : ContentPage
{
	private readonly AllProductViewModel _viewModel;
	public AllProductPage(AllProductViewModel allProductViewModel)
	{
		InitializeComponent();
		_viewModel = allProductViewModel;
		BindingContext = _viewModel;
	}

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}