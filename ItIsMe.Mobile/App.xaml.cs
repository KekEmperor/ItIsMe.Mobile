namespace ItIsMe.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new SignInPage();

        Preferences.Set("StudentId", "BD4A161A-D3D0-4F32-9C01-BDEF44904444");
	}
}
