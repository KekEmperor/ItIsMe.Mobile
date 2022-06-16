using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public class TestQuestionBox : ContentView
{
    private readonly List<View> _optionViews = new List<View>();
    private readonly List<string> _optionNames = new List<string>();
    private readonly string _type;
    private readonly string _question;

    public TestQuestionBox(TestQuestion question)
    {
        _type = question.Type;
        _question = question.Question;
        _optionNames = question.Options;

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

        if (question.Type == "Open" || question.Type == "text")
        {
            var entry = new Entry();

            entry.Focused += OptionChanged;

            content.Add(entry);
            _optionViews.Add(entry);
        }
        else if (question.Type == "Radiobutton" || question.Type == "radio")
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
        else if (question.Type == "Checkbox" || question.Type == "checkbox")
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
        if (_type == "Open" || _type == "text")
        {
            if (string.IsNullOrEmpty(
                ((Entry)_optionViews.First()).Text))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else if (_type == "Radiobutton" || _type == "radio")
        {
            if (_optionViews.Cast<RadioButton>().All(rb => !rb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }
        else if (_type == "Checkbox" || _type == "checkbox")
        {
            if (_optionViews.Cast<CheckBox>().All(cb => !cb.IsChecked))
            {
                Content.BackgroundColor = Color.FromRgb(245, 66, 66);
                return false;
            }
            return true;
        }

        return false;
    }

    public Answer GetAnswerForQuestion()
    {
        var answer = new Answer();
        answer.Question = _question;
        answer.Answers = new List<string>();

        if (_type == "Open" || _type == "text")
        {
            answer.Answers.Add(((Entry)_optionViews.First()).Text);

            return answer;
        }
        else if (_type == "Checkbox" || _type == "checkbox")
        {
            var checkboxes = _optionViews.Cast<CheckBox>();

            for (int i = 0; i < checkboxes.Count(); i++)
            {
                if (checkboxes.ElementAt(i).IsChecked)
                {
                    answer.Answers.Add(_optionNames[i]);
                }
            }

            return answer;
        }
        else if (_type == "Radiobutton" || _type == "radio")
        {
            var radios = _optionViews.Cast<RadioButton>();

            for (int i = 0; i < radios.Count(); i++)
            {
                if (radios.ElementAt(i).IsChecked)
                {
                    answer.Answers.Add(_optionNames[i]);
                }
            }

            return answer;
        }

        return answer;
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