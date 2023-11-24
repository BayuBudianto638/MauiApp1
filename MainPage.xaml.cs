using MauiApp1.Applications.Customers;
using MauiApp1.Models;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
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

}
