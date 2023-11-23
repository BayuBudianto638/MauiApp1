namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Result { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            Result = A + B;
            DisplayAlert("Hello", "This is a Maui Message Dialog!", "OK");
        }
    }

}
