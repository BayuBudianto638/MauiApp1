using MauiApp1.Applications.Customers;
using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class CustomerPage : ContentPage
{
    private readonly ICustomerAppService data = new CustomerAppService();

    public CustomerPage()
    {
        InitializeComponent();

        BindingContext = new CustomerAppService().GetAll();
        //_iCustomerAppService = iCustomerAppService;

    }

    private async void OnAddClick(object sender, EventArgs e)
    {
        await DisplayAlert("Add", "Add Customer", "OK");
        //var customer = new Customer();
        //customer.Name = CustomerName.Text;

        //var custAppService = new CustomerAppService();

        //var (isResult, isMsg) = await custAppService.Save(customer);
        //if (isResult == true)
        //{
        //    await DisplayAlert("Sukses", "Sukses", "OK");
        //}
        //else
        //{
        //    await DisplayAlert("Gagal", "Gagal", "OK");
        //}
    }
}