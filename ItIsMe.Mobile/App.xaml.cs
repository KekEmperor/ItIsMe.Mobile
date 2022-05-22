namespace ItIsMe.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SignInPage();

        Preferences.Set("StudentId", "CC6B4CF1-0AB8-48C5-9C92-664317176773");
	}
}
