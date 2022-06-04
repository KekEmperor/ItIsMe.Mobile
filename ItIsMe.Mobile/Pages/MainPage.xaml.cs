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
        var studentId = Preferences.Get("StudentId", "");

        var assignedTests =
            await RequestHelper.Get<IEnumerable<StudentAssignedTest>>($"assignedStudentTests?studentId={studentId}");

        await Navigation.PushAsync(new CustomTestsMenuPage(assignedTests));
    }

    private async void ProfessionTestsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DefaultTestsMenuPage());
    }
}

