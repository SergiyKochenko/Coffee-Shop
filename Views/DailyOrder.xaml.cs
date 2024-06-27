namespace Coffee_Shop.Views;

public partial class DailyOrder : ContentPage
{
	private readonly DailyOrderViewModel _dailyOrderViewModel;
	public DailyOrder(DailyOrderViewModel dailyOrderViewModel)
	{
        _dailyOrderViewModel = dailyOrderViewModel;
        InitializeComponent();

		BindingContext = _dailyOrderViewModel;
	}
}