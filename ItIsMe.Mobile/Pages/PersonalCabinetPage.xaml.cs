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
                        Text = $"Your last attempt of \"Draw a person\" test showed that your emotional type is {testsResult.EmotionType}. Based on this, the best match for your profession is a position of {testsResult.Profession}",
                        FontSize = 20
                    }

            },
            Padding = 10,
            Spacing = 15
        };

        string tekstovka = "";

        if (testsResult.EmotionType == "Supervisor")
        {
            tekstovka = """Як правило, люди з лідерством і лідерськими нахили, соціальними нормами поведінки, можуть мати дар хорошої розповіді, заснований на високому рівні розвитку мовлення. Вони добре пристосовані в соціальній сфері, домінування над іншими зберігається в певних межах. Слід пам\'ятати, що прояв цих якостей залежить від рівня психічного розвитку. При високому рівні розвитку індивідуальні риси розвитку реалізуються, досить добре усвідомлені. На низькому рівні вони можуть не бути ідентифіковані в професійній діяльності, але можуть бути ситуативними, гіршими, якщо ситуації неадекватні. Це стосується всіх характеристик. Професії в ІТ, що тобі підходять: Software Architect, Business Analyst, Project Manager""";
        }
        else if (testsResult.EmotionType == "Responsible Executor")
        {
            tekstovka = """Цей тип людей має багато рис, таких як «лідер», будучи розташованим до нього, але при прийнятті відповідальних рішень часто виникають коливання. Така людина орієнтується на здатність до ведення бізнесу, високий професіоналізм, має високе почуття відповідальності і вимогливість до себе та інших, високо цінує право, тобто характеризується підвищеною чутливістю до правдивості. Він часто страждає від соматичних захворювань нервового походження через перенапруження. Професії в ІТ, що тобі підходять: UI / UX designer, Developer, QA Engineer""";

        }
        else if (testsResult.EmotionType == "Anxious And Suspicious")
        {
            tekstovka = """Для цього виду людей характерні найрізноманітніші здібності і обдазованість — від тонких ручних навичок до літературної обдазованості. Зазвичай ці люди тісно знаходяться в межах однієї професії, вони можуть змінити її на протилежну і несподівану, також мають хобі, яке насправді є другою професією. Фізично не терпить безладу і бруду. Зазвичай конфліктують через це з іншими людьми. Вони особливо вразливі і часто сумніваються в собі. Вони потребують заохочення. Професії в ІТ, що тобі підходять: UI/UX designer, QA Engineer, HR""";
        }
        else if (testsResult.EmotionType == "Scientist")
        {
            tekstovka = """Ці люди легко абстрагуються від реальності, мають концептуальний розум, здатні розвивати всі свої теорії. Вони зазвичай мають рівновагу розуму і раціонально думають про свою поведінку.Характеризуються здатністю створювати теорії, здебільшого глобальні, або проводити велику і складну координаційну роботу.Також характеризуються великою пристрастю до пізнання життя, здоров'я, біологічних дисциплін, медицини. Професії в ІТ, що тобі підходять: DevOps, QA Engineer, Software Architect""";
        }
        else if (testsResult.EmotionType == "Intuitive")
        {
            tekstovka = """Люди цього типу мають сильну чутливість нервової системи, її високе виснаження. Легше працювати над переходом від однієї діяльності до іншої, зазвичай вони є адвокатами меншості. Вони дуже чутливі до новизни. Альтруїстичні, часто доглядають за іншими, мають гарні ручні навички та уяву уяви, що дає їм можливість займатися технічними формами творчості. Вони зазвичай розробляють власні моральні норми, мають внутрішній самоконтроль, тобто віддають перевагу самоконтролю, реагуючи негативно на порушення своєї свободи. Професії в ІТ, що тобі підходять: UI/UX designer, Business Analyst, Project Manager""";
        }
        else if (testsResult.EmotionType == "Inventor And Designer And Artist")
        {
            tekstovka = """Часто зустрічається серед людей з технічними прожилками. Ці люди, які мають багату уяву, просторове бачення, часто займаються різними видами технічної, художньої та інтелектуальної творчості. Частіше інтроверти, як і інтуїтивний тип, живуть власними моральними нормами, не приймають будь-яких сторонніх впливів, окрім самоконтролю. Емоційний, одержимий власними оригінальними ідеями. Професії в ІТ, що тобі підходять Software Architect, UI/UX designer, Business Analyst""";
        }
        else if (testsResult.EmotionType == "Emotive")
        {
            tekstovka = """У них підвищена емпатія до інших, важко вражені брутальним кадрами фільму, можуть довго бути поза ладом і бути шоковані бурхливі події. Біль і тривога інших людей бере участь, співпереживання і співпереживання, за які вони витрачають багато власної енергії, утруждаючи реалізувати власні здібності. Професії в ІТ, що тобі підходять: UI/UX designer, Business Analyst, HR""";
        }
        else
        {
            tekstovka = """Цей тип людини має протилежну тенденцію до емоційного типу. Зазвичай не відчуває чужих почуттів, або ставиться до них з халатністю, або навіть підвищує тиск на людей. Якщо він хороший експерт, він може змусити інших робити те, що думає, правильно. Іноді для неї характерна безсердечність, яка виникає ситуативно, коли з якихось причин людина закривається в колі власних проблем. Професії в ІТ, що тобі підходять: Developer, QA Engineer, Project Manager.""";
        }

        var tekstovkaLabel = new Label
        {
            Text = tekstovka + "; результат точніше встановлює фінальний тест.",
            FontSize = 15
        };

        layout.Children.Add(tekstovkaLabel);

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

        Content = new ScrollView
        {
            Content = layout
        };
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