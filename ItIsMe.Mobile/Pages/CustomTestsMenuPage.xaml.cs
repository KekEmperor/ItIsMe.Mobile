using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public partial class CustomTestsMenuPage : ContentPage
{
	public CustomTestsMenuPage(IEnumerable<StudentAssignedTest> assignedTests)
	{
		var layout = new VerticalStackLayout();

		var filteredTests = assignedTests.Where(t => t.Test.Name != "Draw a person"
												  && t.Test.Name != "IT speciality test");

		foreach (var assignedTest in filteredTests)
        {
			layout.Children.Add(new CustomTestBox(assignedTest));
        }

		Content = layout;
	}
}