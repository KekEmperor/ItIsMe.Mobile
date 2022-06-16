namespace ItIsMe.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SignInPage();

        Preferences.Set("StudentId", "1D09EE93-1B92-463B-A8B9-077C50248021");
	}
}
