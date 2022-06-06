using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class MoodTestPage : ContentPage
{
    public MoodTestPage()
    {
        InitializeComponent();
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
        await RequestHelper.PostImage(fileResult, "1b78cd12-c3bd-4da9-5616-08da471f17eb");

    }
}