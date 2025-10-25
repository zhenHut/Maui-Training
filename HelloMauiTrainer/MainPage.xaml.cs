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
            string city = CityEntry.Text;
            var now = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(city))
            {
                await Navigation.PushAsync(new WelcomePage(city, now));
            }
        }
    }

}
