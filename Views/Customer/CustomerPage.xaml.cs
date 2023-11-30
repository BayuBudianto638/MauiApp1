using MauiApp1.Applications.Customers;
using MauiApp1.Models;
using MauiApp1.ViewModels;
using MauiApp1.Views.Customer;

namespace MauiApp1.Views;

public partial class CustomerPage : ContentPage
{
    private readonly CustomerViewModel _viewModel;

    public CustomerPage(CustomerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    private async void OnAddClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPageAdd());
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadCustomersAsync();
    }
}