using MauiApp1.Applications.Customers;
using MauiApp1.Views;

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
    }

}
