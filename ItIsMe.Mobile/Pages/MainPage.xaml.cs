using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void DrawTestButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DrawTestPage());
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

    private async void ItSpecialityTestButtonClicked(object sender, EventArgs e)
    {
        var test = await RequestHelper.Get<Test>($"tests/{DefaultTestsHelper.IT_TEST_ID}");

        await Navigation.PushAsync(new CustomTestPage(test));
    }

    private async void ProfessionTestsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DefaultTestsMenuPage());
    }
}

