using MauiApp1.Views.Product;

namespace MauiApp1.Views;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();
	}

    private async void OnAddClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPageAdd());
    }
}