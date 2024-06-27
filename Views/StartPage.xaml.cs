namespace Coffee_Shop.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(HomePage), animate: true);
    }
}