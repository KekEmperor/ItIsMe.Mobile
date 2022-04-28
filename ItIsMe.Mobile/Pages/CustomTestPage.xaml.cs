using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using Newtonsoft.Json;

namespace ItIsMe.Mobile;

public partial class CustomTestPage : ContentPage
{
	private readonly List<TestQuestionBox> QuestionBoxesList = new List<TestQuestionBox>();

	public CustomTestPage(Test test)
	{
		InitializeComponent();

		ScrollView parentScrollView = new ScrollView();

		VerticalStackLayout questionsHolder = new VerticalStackLayout()
        {
			Padding = 15,
			Spacing = 10
        };
		parentScrollView.Content = questionsHolder;

        List<TestQuestion> questionsList =
            JsonConvert.DeserializeObject<List<TestQuestion>>(test.ContentJson);

        foreach (var question in questionsList)
        {
			var questionBox = new TestQuestionBox(question);

			questionsHolder.Children.Add(questionBox);
			QuestionBoxesList.Add(questionBox);
        }

		Button submitButton = new Button()
		{
			Text = "Submit the test"
		};
		submitButton.Clicked += SubmitButtonClicked;

		questionsHolder.Children.Add(submitButton);

		Content = parentScrollView;
	}

	private async void SubmitButtonClicked(object sender, EventArgs e)
    {
		if (QuestionBoxesList.All(qb => qb.DoesQuestionHaveAnswer()))
        {
			 await Navigation.PopAsync();
        }

		await DisplayAlert("Error", "Answer all the questions of the test please", "Got it");
    }
}