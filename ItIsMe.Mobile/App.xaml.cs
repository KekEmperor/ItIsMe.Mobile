namespace ItIsMe.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SignInPage();

        Preferences.Set("StudentId", "923FB40B-89A2-4489-BDA0-0BB6B19B465C");
	}
}
