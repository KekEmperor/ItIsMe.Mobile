using ItIsMe.Mobile.Helpers;
using ItIsMe.Mobile.Pages.Interfaces;

namespace ItIsMe.Mobile;

public partial class MoodTestPage : ContentPage
{
    private readonly IRefreshablePage _parentPage;

    public MoodTestPage(IRefreshablePage parentPage)
    {
        InitializeComponent();

        _parentPage = parentPage;
    }

    private async void TakePhotoButtonClicked(object sender, EventArgs e)
    {
        FileResult fileResult = await MediaPicker.CapturePhotoAsync();

        if (fileResult != null)
        {
            await SendPictureForAnalysis(fileResult);
        }
    }

    private async void UploadImageButtonClicked(object sender, EventArgs e)
    {
        FileResult fileResult = await MediaPicker.PickPhotoAsync();

        if (fileResult != null)
        {
            await SendPictureForAnalysis(fileResult);
        }
    }

    private async Task SendPictureForAnalysis(FileResult fileResult)
    {
        var response = await DefaultTestsHelper.SendImage(fileResult);

        if (response == System.Net.HttpStatusCode.OK)
        {
            await DisplayAlert(
                "Success",
                "You have successfully uploaded the photo for analysis. " +
                "Please come back later to see results!",
                "Got it");
        }
        else
        {
            await DisplayAlert(
                "Error",
                "Something has happened during the upload. " +
                "Please try again later.",
                "Got it");
        }

        DefaultTestsHelper.IsMoodGotten = true;
        DefaultTestsHelper.IsMoodAllowed = true;

        _parentPage.Refresh();

        await Navigation.PopAsync();
    }
}