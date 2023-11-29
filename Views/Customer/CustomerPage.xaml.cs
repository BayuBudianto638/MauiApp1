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

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var listData = await data.GetAll();
        myCollectionView.ItemsSource = listData;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        var selectedItem = (CustomerModel)((Button)sender).BindingContext;
        await Navigation.PushAsync(new CustomerPageDetail(selectedItem));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Do you want to delete this record?", "Yes", "No");

        if (answer.Equals(true))
        {
            var selectedItem = (CustomerModel)((Button)sender).BindingContext;
            var isDeleted = await data.Delete(selectedItem.Id);

            if (isDeleted.Equals(true))
            {
                await DisplayAlert("Information", "Record deleted!!", "Ok");
            }
        }
    }
}