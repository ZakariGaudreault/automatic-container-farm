namespace Econtainer.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void Login_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new DashboardPage());
	}

	private void Sign_Up_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SignUpPage());

	}
}