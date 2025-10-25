namespace HelloMauiTrainer
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                await Navigation.PushAsync(new WelcomePage(name));
            }
        }
    }

}
