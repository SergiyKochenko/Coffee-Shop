using Coffee_Shop.ViewModels;

namespace Coffee_Shop.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        _homeViewModel = homeViewModel;
        BindingContext = _homeViewModel;
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {

    }
}