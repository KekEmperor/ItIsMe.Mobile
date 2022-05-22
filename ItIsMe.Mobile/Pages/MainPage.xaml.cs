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

    private async void CustomTestsButtonClicked(object sender, EventArgs e)
    {
        var studentId = Preferences.Get("StudentId", "");

        var assignedTests =
            await RequestHelper.Get<IEnumerable<StudentAssignedTest>>($"assignedStudentTests?studentId={studentId}");

        await Navigation.PushAsync(
            new NavigationPage(new CustomTestsMenuPage(assignedTests)));
    }

    private async void MoodTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new NavigationPage(new MoodTestPage()));
    }
}

