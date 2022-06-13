using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public class TestQuestionBox : ContentView
{
    private readonly List<View> _optionViews = new List<View>();
    private readonly string _type;

    public TestQuestionBox(TestQuestion question)
    {
        _type = question.Type;

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
            _optionViews.Add(entry);
        }
        else if (question.Type == "Radiobutton")
        {
            foreach (var option in question.Options)
            {
                var radioButton = new RadioButton()
                {
                    Content = option
                };

                radioButton.CheckedChanged += OptionChanged;

                content.Add(radioButton);
                _optionViews.Add(radioButton);
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
                _optionViews.Add(checkBox);
            }
        }

        Content = content;
    }

    public bool DoesQuestionHaveAnswer()
    {
        if (_type == "Open")
        {
            if (string.IsNullOrEmpty(
                ((Entry)_optionViews.First()).Text))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else if (_type == "Radiobutton")
        {
            if (_optionViews.Cast<RadioButton>().All(rb => !rb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else
        {
            if (_optionViews.Cast<CheckBox>().All(cb => !cb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
    }

    public string GetAnswerForQuestion()
    {
        throw new NotImplementedException();
    }

    public string GetOptionForQuestion()
    {
        var radioButtonsList = _optionViews.Cast<RadioButton>();

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