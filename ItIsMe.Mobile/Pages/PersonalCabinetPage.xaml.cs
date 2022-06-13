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
                    },

            },
            Padding = 10,
            Spacing = 15
        };

        var telegramButton = new Button
        {
            Text = "Open Telegram Bot",
            Margin = new Thickness(0, 10, 0, 0)
        };

        telegramButton.Clicked += OpenBotButtonClicked;

        layout.Children.Add(telegramButton);

        var commentsButton = new Button
        {
            Text = "Review comments",
            Margin = new Thickness(0, 50, 0, 0)
        };

        commentsButton.Clicked += ReviewCommentsButtonClicked;

        layout.Children.Add(commentsButton);

        Content = layout;
    }

    private async void ReviewCommentsButtonClicked(object sender, EventArgs e)
    {
        var comments = await RequestHelper.Get<IEnumerable<SessionComment>>(
            $"sessionComments/getSessionCommentsForStudent?studentId={Preferences.Get("StudentId", "")}");

        await Navigation.PushAsync(new CommentsPage(comments));
    }

    private async void OpenBotButtonClicked(object sender, EventArgs e)
    {
        Uri uri = new Uri("https://t.me/eva_project_bot");
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.External);
    }
}