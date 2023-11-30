using MauiApp1.Applications.Customers;
using MauiApp1.ViewModels;
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
            var customerAppService = new CustomerAppService(); 
            var customerViewModel = new CustomerViewModel(customerAppService, Navigation);
            var customerPage = new CustomerPage(customerViewModel);

            await Navigation.PushAsync(customerPage);            
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
