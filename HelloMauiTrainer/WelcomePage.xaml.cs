namespace HelloMauiTrainer;

public partial class WelcomePage : ContentPage
{
    public WelcomePage(string name)
    {
        InitializeComponent();
        WelcomeLabel.Text = $"Willkommen, {name}!";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}