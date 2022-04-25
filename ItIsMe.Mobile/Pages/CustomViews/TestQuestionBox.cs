using ItIsMe.Mobile.DataModels;

namespace ItIsMe.Mobile;

public class TestQuestionBox : ContentView
{
	private List<View> optionViewsList = new List<View>();

	public TestQuestionBox(TestQuestion question)
	{
		var content = new StackLayout
		{
			Children = {
				new Label { Text = question.Question }
			},
			Spacing = 10,
			Padding = 25
		};

		if (question.Options.Count == 0)
        {
			var entry = new Entry();

            content.Add(entry);
			optionViewsList.Add(entry);
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
				optionViewsList.Add(radioButton);
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
				optionViewsList.Add(checkBox);
			}
		}

		Content = content;
    }
}