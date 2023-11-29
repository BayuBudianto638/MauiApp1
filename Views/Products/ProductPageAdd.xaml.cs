using MauiApp1.Applications.Products;
using MauiApp1.Models;

namespace MauiApp1.Views.Product;

public partial class ProductPageAdd : ContentPage
{
	public ProductPageAdd()
	{
		InitializeComponent();
	}

    private async void OnSaveClick(object sender, EventArgs e)
    {
        var product = new ProductModel();
        product.Name = ProductName.Text;
        product.Price = Convert.ToInt32(ProductPrice.Text);

        var prodAppService = new ProductAppService();

        var (isResult, isMsg) = await prodAppService.Save(product);
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