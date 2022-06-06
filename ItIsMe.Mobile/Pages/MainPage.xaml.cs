using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void CustomTestsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CustomTestsMenuPage());
    }

    private async void ProfessionTestsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DefaultTestsMenuPage());
    }

    private async void PersonalCabinetButtonClicked(object sender, EventArgs e)
    {
        var studentId = Preferences.Get("StudentId", "");

        var student = await RequestHelper.Get<Student>($"students/{studentId}");

        var professionTestsResult =
            await RequestHelper.Get<ProfessionTestsResult>(
                $"assignedStudentTests/getLastProfessionTestsResult?studentId={studentId}");

        await Navigation.PushAsync(new PersonalCabinetPage(student, professionTestsResult));
    }

    private async void SessionsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SessionsPage());
    }
}

