using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public partial class SessionsPage : ContentPage
{
    public SessionsPage(IEnumerable<Session> sessions)
    {
        InitializeComponent();

        var layout = new StackLayout
        {
            Spacing = 10,
            Padding = 10
        };

        var button = new Button
        {
            Text = "Add session to the calendar"
        };

        button.Clicked += async (sender, e) =>
        {
            Uri uri = new Uri("https://calendar.google.com/calendar/u/1/r/eventedit?vcon=meet&dates=now");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.External);
        };

        layout.Children.Add(button);

        if (sessions.Count() == 0 || sessions == null)
        {
            layout.Children.Add(new Label
            {
                Text = "You have not got any session records yet.",
                HorizontalOptions = LayoutOptions.Center
            });
        }
        else
        {
            foreach (var session in sessions)
            {
                layout.Children.Add(new Frame
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "Session holder:"
                            },
                            new Label
                            {
                                Text = session.Psychologist.FullName,
                                FontSize = 20
                            },
                            new Label
                            {
                                Text = "Start date: " + session.Date.ToString("g"),
                                Margin = new Thickness(0,15,0,0)
                            }
                        }
                    },
                    BorderColor = Color.FromArgb("#BABABA"),
                    BackgroundColor = session.IsHandled ? Color.FromArgb("#EAEAEA") : Color.FromArgb("#FFFFFF")
                });
            }
        }

        Content = new ScrollView
        {
            Content = layout
        };
    }
}