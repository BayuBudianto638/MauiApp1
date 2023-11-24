using MauiApp1.Applications.Customers;
using MauiApp1.Models;

namespace MauiApp1.Views;

public partial class CustomerPage : ContentPage
{
	public CustomerPage()
	{
		InitializeComponent();
	}

    private void OnSaveClick(object sender, EventArgs e)
    {
        var customer = new Customer();
        customer.Name = CustomerName.Text;

        var custAppService = new CustomerAppService();

        var (isResult, isMsg) = custAppService.Save(customer);
        if (isResult == true)
        {
            DisplayAlert("Sukses", "Sukses", "OK");
        }
        else
        {
            DisplayAlert("Gagal", "Gagal", "OK");
        }
    }
}