using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public class TestQuestionBox : ContentView
{
    private readonly List<View> OptionViews = new List<View>();
    private readonly string Type;

    public TestQuestionBox(TestQuestion question)
    {
        Type = question.Type;

        var content = new StackLayout
        {
            Children = {
                new Label
                {
                    Text = question.Question
                }
            },
            Spacing = 10,
            Padding = 5
        };

        if (question.Type == "Open")
        {
            var entry = new Entry();

            entry.Focused += OptionChanged;

            content.Add(entry);
            OptionViews.Add(entry);
        }
        else if (question.Type == "Radio")
        {
            foreach (var option in question.Options)
            {
                var radioButton = new RadioButton()
                {
                    Content = option
                };

                radioButton.CheckedChanged += OptionChanged;

                content.Add(radioButton);
                OptionViews.Add(radioButton);
            }
        }
        else
        {
            foreach (var option in question.Options)
            {
                var checkBox = new CheckBox();

                checkBox.CheckedChanged += OptionChanged;

                content.Add(new HorizontalStackLayout()
                {
                    Children = {
                        checkBox,
                        new Label()
                        {
                            Text = option,
                            VerticalOptions = LayoutOptions.Center
                        }
                    },
                    VerticalOptions = LayoutOptions.Center
                });
                OptionViews.Add(checkBox);
            }
        }

        Content = content;
    }

    public bool DoesQuestionHaveAnswer()
    {
        if (Type == "Open")
        {
            if (string.IsNullOrEmpty(
                ((Entry)OptionViews.First()).Text))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else if (Type == "Radio")
        {
            if (OptionViews.Cast<RadioButton>().All(rb => !rb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else
        {
            if (OptionViews.Cast<CheckBox>().All(cb => !cb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
    }

    public string GetResultForQuestion()
    {
        throw new NotImplementedException();
    }

    public string GetOptionForQuestion()
    {
        var radioButtonsList = OptionViews.Cast<RadioButton>();

        if (radioButtonsList.ElementAt(0).IsChecked)
        {
            return "A";
        }
        else if (radioButtonsList.ElementAt(1).IsChecked)
        {
            return "B";
        }
        else
        {
            return "C";
        }
    }

    private void OptionChanged(object sender, EventArgs e)
    {
        Content.BackgroundColor = Color.FromRgb(255, 255, 255);
    }
}