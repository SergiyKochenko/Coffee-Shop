namespace Coffee_Shop.Views;

public partial class HotDrinkPage : ContentPage
{
	private readonly HotDrinkViewModel _hotDrinkViewModel;
	public HotDrinkPage(HotDrinkViewModel hotDrinkViewModel)
	{
		InitializeComponent();
		_hotDrinkViewModel = hotDrinkViewModel;
		BindingContext = _hotDrinkViewModel;
	}
}