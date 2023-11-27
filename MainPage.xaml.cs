using MauiApp1.Applications.Customers;
using MauiApp1.Views;
using MauiApp1.Views.Sales;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCustomerClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerPage());            
        }

        private async void OnProductClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }

        private async void OnSalesClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SalesPage());
        }
    }

}
