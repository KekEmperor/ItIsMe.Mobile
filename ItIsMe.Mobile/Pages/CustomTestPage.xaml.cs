using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using ItIsMe.Mobile.Pages.Interfaces;
using ItIsMe.Mobile.RequestModels.AssignStudentTest;
using Newtonsoft.Json;

namespace ItIsMe.Mobile;

public partial class CustomTestPage : ContentPage
{
    private readonly IRefreshablePage _parentPage;

    private readonly List<TestQuestionBox> _questionBoxesList = new List<TestQuestionBox>();
    private readonly Test _test;

    public CustomTestPage(Test test, IRefreshablePage parentPage = null)
    {
        InitializeComponent();

        Title = test.Name;

        _parentPage = parentPage;

        _test = test;

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
            _questionBoxesList.Add(questionBox);
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
        if (!_questionBoxesList.All(qb => qb.DoesQuestionHaveAnswer()))
        {
            await DisplayAlert("Error", "Answer all the questions of the test please", "Got it");
            return;
        }

        if (_test.Name == "IT speciality test")
        {
            var result = new ItSpecialityTestRequest();

            foreach (var qb in _questionBoxesList)
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

        if (_parentPage != null)
        {
            _parentPage.Refresh();
        }

        await Navigation.PopAsync();
    }
}