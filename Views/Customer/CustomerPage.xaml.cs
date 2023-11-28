using MauiApp1.Applications.Customers;
using MauiApp1.Models;
using MauiApp1.Views.Customer;

namespace MauiApp1.Views;

public partial class CustomerPage : ContentPage
{
    private readonly ICustomerAppService data = new CustomerAppService();

    public CustomerPage()
    {
        InitializeComponent();

        BindingContext = new CustomerAppService().GetAll();

    }

    private async void OnAddClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomerPageAdd());
    }
}