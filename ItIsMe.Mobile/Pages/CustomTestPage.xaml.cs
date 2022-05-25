using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using Newtonsoft.Json;

namespace ItIsMe.Mobile;

public partial class CustomTestPage : ContentPage
{
    private readonly List<TestQuestionBox> QuestionBoxesList = new List<TestQuestionBox>();
    private readonly Test Test;

    public CustomTestPage(Test test)
    {
        InitializeComponent();

        Test = test;

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
        if (!QuestionBoxesList.All(qb => qb.DoesQuestionHaveAnswer()))
        {
            await DisplayAlert("Error", "Answer all the questions of the test please", "Got it");
            return;
        }

        if (Test.Name == "IT speciality test")
        {
            var result = new ItSpecialityTestAnswers();

            foreach (var qb in QuestionBoxesList)
            {
                switch (qb.GetOptionForQuestion())
                {
                    case "A":
                        result.A++;
                        break;
                    case "B":
                        result.B++;
                        break;
                    case "C":
                        result.C++;
                        break;
                }
            }

            DefaultTestsHelper.ItSpecialityTestAnswers = result;
        }

        await Navigation.PopAsync();
    }
}