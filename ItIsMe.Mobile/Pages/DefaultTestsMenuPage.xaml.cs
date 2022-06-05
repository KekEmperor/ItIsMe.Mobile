using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using ItIsMe.Mobile.Pages.Interfaces;

namespace ItIsMe.Mobile;

public partial class DefaultTestsMenuPage : ContentPage, IRefreshablePage
{
    public DefaultTestsMenuPage()
    {
        InitializeComponent();

        Refresh();
    }

    private async void MoodTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new NavigationPage(new MoodTestPage()));
    }

    private async void DrawTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DrawTestPage(this));
    }

    private async void ItSpecialityTestButtonClicked(object sender, EventArgs e)
    {
        var test = await RequestHelper.Get<Test>($"tests/{DefaultTestsHelper.IT_TEST_ID}");

        await Navigation.PushAsync(new CustomTestPage(test, this));
    }

    private async void SubmitTestsButtonClicked(object sender, EventArgs e)
    {
        if (DefaultTestsHelper.SendResults())
        {
            await DisplayAlert("Success", "You have successfully performed profession tests. Check out your results in your personal cabinet!", "Got it");
        }
        else
        {
            await DisplayAlert("Error", "Something went wrong. Please try sending again later.", "Got it");
        }
    }

    public void Refresh()
    {
        SubmitButton.IsEnabled = DefaultTestsHelper.AreTestsCompleted;
    }
}