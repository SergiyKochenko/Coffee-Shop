namespace Coffee_Shop.Views;

public partial class ColdDrinkPage : ContentPage
{
	private readonly ColdDrinkViewModel _viewModel;
	public ColdDrinkPage(ColdDrinkViewModel coldDrinkViewModel)
	{
		InitializeComponent();
		_viewModel = coldDrinkViewModel;
		BindingContext = _viewModel;
	}
}