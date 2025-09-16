using Econtainer.Views;

namespace Econtainer;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		this.BackgroundImageSource = "plants_background.png";
	}

	private void Login_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new LoginPage());
	}

	private void Sign_Up_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new SignUpPage());
	}
}

