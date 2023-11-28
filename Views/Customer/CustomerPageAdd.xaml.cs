using MauiApp1.Applications.Customers;
using MauiApp1.Models;

namespace MauiApp1.Views.Customer;

public partial class CustomerPageAdd : ContentPage
{
	public CustomerPageAdd()
	{
		InitializeComponent();
	}

    private async void OnSaveClick(object sender, EventArgs e)
    {
        var customer = new CustomerModel();
        customer.Name = CustomerName.Text;

        var custAppService = new CustomerAppService();

        var (isResult, isMsg) = await custAppService.Save(customer);
        if (isResult == true)
        {
            await DisplayAlert("Sukses", "Sukses", "OK");
        }
        else
        {
            await DisplayAlert("Gagal", "Gagal", "OK");
        }
    }
}