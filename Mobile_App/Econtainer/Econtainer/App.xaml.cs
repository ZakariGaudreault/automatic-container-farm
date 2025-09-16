namespace Econtainer;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		MainPage.BackgroundImageSource = "C:\\Users\\ronfu\\final-project-the-goons\\Mobile_App\\Econtainer\\Econtainer\\Images\\plants-background.png";
	}
}
