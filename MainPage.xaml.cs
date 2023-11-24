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
            A = Convert.ToInt32(textA.Text);
            B = Convert.ToInt32(textB.Text);

            Result = A + B;

            textResult.Text = Result.ToString();
                       
            SemanticScreenReader.Announce(textResult.Text);

            //DisplayAlert("Hello", "This is a Maui Message Dialog!", "OK");
        }
    }

}
