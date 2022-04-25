namespace ItIsMe.Mobile;

public partial class MainPage : ContentPage
{public MainPage()
	{
		InitializeComponent();
	}

    private async void DrawTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new DrawTestPage()));
    }
}

