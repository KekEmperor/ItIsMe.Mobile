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

		VerticalStackLayout questionsHolder = new VerticalStackLayout();
		parentScrollView.Content = questionsHolder;

		List<TestQuestion> questionsList =
			JsonConvert.DeserializeObject<List<TestQuestion>>(test.ContentJson);

		foreach (var question in questionsList)
        {
			var questionBox = new TestQuestionBox(question);

			questionsHolder.Children.Add(questionBox);
			QuestionBoxesList.Add(questionBox);
        }

		Content = parentScrollView;
	}
}