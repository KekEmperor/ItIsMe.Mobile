using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public class CustomTestBox : ContentView
{
	private readonly StudentAssignedTest _assignedTest;

	public CustomTestBox(StudentAssignedTest assignedTest)
	{
		_assignedTest = assignedTest;

		var layout = new StackLayout
		{
			Children = {
				new Label { Text = assignedTest.Test.Name }
			}
		};

		var tapGesture = new TapGestureRecognizer();
		tapGesture.Tapped += BoxTapped;
		layout.GestureRecognizers.Add(tapGesture);

		Content = layout;
	}

	private async void BoxTapped(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CustomTestPage(_assignedTest.Test));
    }
}