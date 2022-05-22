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

        await SendPictureForAnalysis(fileResult);
    }

    private async void UploadImageButtonClicked(object sender, EventArgs e)
    {
        FileResult fileResult = await MediaPicker.PickPhotoAsync();

        await SendPictureForAnalysis(fileResult);
    }

    private async Task SendPictureForAnalysis(FileResult fileResult)
    {

    }
}