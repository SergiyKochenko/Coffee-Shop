using System.Diagnostics;

namespace Coffee_Shop.Views;

public partial class OrderSummary : ContentPage
{
	private readonly OrderSummaryViewModel _viewModel;




    public OrderSummary(OrderSummaryViewModel orderSummaryViewModel)
    {
        _viewModel = orderSummaryViewModel;
        InitializeComponent();
        BindingContext = _viewModel;
    }


    
}