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
		DefaultTestsHelper.SendResults();
    }
}