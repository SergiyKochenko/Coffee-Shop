namespace Coffee_Shop.Views;

public partial class FoodPage : ContentPage
{
	private readonly FoodViewModel _foodViewModel;
	public FoodPage(FoodViewModel foodViewModel)
	{
		InitializeComponent();
		_foodViewModel = foodViewModel;
		BindingContext = _foodViewModel;
	}
}