using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class DefaultTestsMenuPage : ContentPage
{
    public DefaultTestsMenuPage()
    {
        InitializeComponent();
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
}