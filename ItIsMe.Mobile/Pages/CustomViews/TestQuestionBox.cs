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
				new Label { Text = question.Question }
			},
			Spacing = 10,
			Padding = 25
		};

		if (question.Type == "Open")
        {
			var entry = new Entry();

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

				content.Add(radioButton);
				OptionViews.Add(radioButton);
            }
        }
		else
        {
			foreach (var option in question.Options)
			{
				var checkBox = new CheckBox();

				content.Add(new HorizontalStackLayout()
                {
					Children = { checkBox, new Label() { Text = option } }
                });
				OptionViews.Add(checkBox);
			}
		}

		Content = content;
    }

	private bool IsQuestionHasAnswer()
    {
		if (Type == "Open")
        {
			if (((Entry)OptionViews.First()).Text.Length == 0)
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
}