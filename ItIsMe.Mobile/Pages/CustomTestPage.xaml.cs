using ItIsMe.Mobile.DataModels;
using ItIsMe.Mobile.Helpers;
using ItIsMe.Mobile.Pages.Interfaces;
using ItIsMe.Mobile.RequestModels.AssignStudentTest;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ItIsMe.Mobile;

public partial class CustomTestPage : ContentPage
{
    private readonly IRefreshablePage _parentPage;

    private readonly List<TestQuestionBox> _questionBoxesList = new List<TestQuestionBox>();
    private readonly Test _test;
    private readonly string _assignedTestId;

    public CustomTestPage(Test test, IRefreshablePage parentPage = null, string assignedTestId = null)
    {
        InitializeComponent();

        Title = test.Name;

        _parentPage = parentPage;

        _test = test;

        _assignedTestId = assignedTestId;

        ScrollView parentScrollView = new ScrollView();

        VerticalStackLayout questionsHolder = new VerticalStackLayout()
        {
            Padding = 15,
            Spacing = 10
        };
        parentScrollView.Content = questionsHolder;

        List<TestQuestion> questionsList =
            JsonConvert.DeserializeObject<TestContent>(test.ContentJson).Quiz;

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

        var answers = new List<Answer>();

        HttpStatusCode response = HttpStatusCode.OK;

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
        else
        {
            foreach (TestQuestionBox tb in _questionBoxesList)
            {
                answers.Add(tb.GetAnswerForQuestion());
            }

            ResultContent testAnswers = new ResultContent
            {
                Result = JsonConvert.SerializeObject(answers)
            };

            response = await RequestHelper.PostCustomTestResult(JsonConvert.SerializeObject(testAnswers), _assignedTestId);
        }

        if (response == System.Net.HttpStatusCode.OK)
        {
            if (_parentPage != null)
            {
                _parentPage.Refresh();
            }

            await Navigation.PopAsync();
        }
    }
}