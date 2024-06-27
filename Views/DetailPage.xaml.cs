namespace Coffee_Shop.Views;

public partial class DetailPage : ContentPage
{
	private readonly DetailViewModel _detailViewModel;
	public DetailPage(DetailViewModel detailViewModel)
	{
		InitializeComponent();
		_detailViewModel = detailViewModel;
		BindingContext = _detailViewModel;
	}

    

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..", animate: true);
    }
}