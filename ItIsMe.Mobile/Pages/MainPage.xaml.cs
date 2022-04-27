using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class MainPage : ContentPage
{public MainPage()
	{
		InitializeComponent();
	}

    private async void DrawTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new NavigationPage(new DrawTestPage()));
    }

    private async void TestButtonClicked(object sender, EventArgs e)
    {
        var testId = "DFDCBF6E-6D09-4A99-B752-B6F4C6A783B1";

        var test = await RequestHelper.Get<Test>($"tests/{testId}");

        await Navigation.PushAsync(
            new NavigationPage(new CustomTestPage(test)));
    }
}

