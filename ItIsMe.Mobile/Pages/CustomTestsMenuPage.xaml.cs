using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using ItIsMe.Mobile.Pages.Interfaces;

namespace ItIsMe.Mobile;

public partial class CustomTestsMenuPage : ContentPage, IRefreshablePage
{
    public CustomTestsMenuPage()
    {
        Refresh();
    }

    public async void Refresh()
    {
        var studentId = Preferences.Get("StudentId", "");

        var assignedTests =
            await RequestHelper.Get<IEnumerable<StudentAssignedTest>>($"assignedStudentTests?studentId={studentId}");

        var layout = new VerticalStackLayout
        {
            Spacing = 10,
            Padding = 10
        };

        var filteredTests = assignedTests.Where(t => t.Test.Name != "Draw a person"
                                                  && t.Test.Name != "IT speciality test"
                                                  && !t.IsCompleted);

        if (filteredTests.Any())
        {
            foreach (var assignedTest in filteredTests)
            {
                layout.Children.Add(new CustomTestBox(assignedTest, this));
            }
        }
        else
        {
            layout.Children.Add(new Label
            {
                Text = "No tests assigned for you yet!",
                HorizontalOptions = LayoutOptions.Center
            });
        }

        Content = layout;
    }
}