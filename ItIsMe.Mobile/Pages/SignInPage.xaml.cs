namespace ItIsMe.Mobile;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}

    private void SignInButtonClicked(object sender, EventArgs e)
    {
		Application.Current.MainPage = new MainPage();
    }
}