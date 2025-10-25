namespace HelloMauiTrainer;

public partial class WelcomePage : ContentPage
{
    public WelcomePage(string city, DateTime time)
    {
        InitializeComponent();
        WelcomeLabel.Text = $"Willkommen in {city}!";
        TimeLabel.Text = $"Zeitpunkt des Eintritts: {time:HH:mm:ss}";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}