using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;

namespace ItIsMe.Mobile;

public partial class PersonalCabinetPage : ContentPage
{
	public PersonalCabinetPage(Student student, ProfessionTestsResult testsResult)
	{
		InitializeComponent();

		var groupFullCode = string.Join('-',
			student.Group.EducationalProgram.Code,
			student.Group.Year % 1000,
			student.Group.Number);

		var layout = new StackLayout
		{
			Children =
			{
				new Label
				{
					Text = $"{student.FullName}",
					FontSize = 25
				},
				new Label
                {
					Text = $"Academic group: {groupFullCode}",
					FontSize = 15
                },
				new Label
                {
					Text = $"Date of birth: {student.DOB.ToString("d")}",
					FontSize = 15
                },
				new Label
                {
					Text = $"Profession tests taken: {testsResult.AttemptsCount}",
					FontSize = 20,
					Padding = new Thickness(0, 30, 0, 0)
                },
				testsResult.AttemptsCount == 0 
				?
					new Label
                    {
						Text = "You have not passed any profession tests yet. Please try to pass one and come back here for the result!",
						FontSize = 20
                    }
				:
					new Label
                    {
						Text = $"Your last attempt of \"Draw a person\" test showed that your emotional type is {testsResult.EmotionType}. Based on this, final test result for your profession was a position of {testsResult.Profession}",
						FontSize = 20
					}
					
			},
			Padding = 10,
			Spacing = 15
		};

		Content = layout;
	}
}