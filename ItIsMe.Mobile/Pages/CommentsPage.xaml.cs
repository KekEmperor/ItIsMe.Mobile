using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public partial class CommentsPage : ContentPage
{
    public CommentsPage(IEnumerable<SessionComment> comments)
    {
        InitializeComponent();

        var layout = new StackLayout
        {
            Spacing = 10,
            Padding = 10
        };

        if (comments.Count() == 0 || comments == null)
        {
            layout.Children.Add(new Label
            {
                Text = "Psychologists have not left any comments for you yet.",
                HorizontalOptions = LayoutOptions.Center
            });
        }
        else
        {
            foreach (var comment in comments)
            {
                layout.Children.Add(new Frame
                {
                    Content = new StackLayout
                    {
                        Children = 
                        {
                            new Label {
                                Text = $"{comment.Session.Psychologist.FullName}, {comment.Session.Date.ToString("d")}",
                                FontSize = 15
                            },
                            new Label
                            {
                                Text = comment.Comment,
                                FontSize = 20
                            }
                        },
                        Spacing = 10,
                    },
                    BorderColor = Color.FromArgb("#BABABA")
                });
            }
        }

        Content = layout;
    }
}