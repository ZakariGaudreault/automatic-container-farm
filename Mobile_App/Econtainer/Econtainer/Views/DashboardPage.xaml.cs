namespace Econtainer.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
	}

	private void PlantSubsystem_Tapped(object sender, TappedEventArgs e)
	{
		Navigation.PushAsync(new PlantSubsystemPage());
	}

    private void LocationSubsystem_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LocationSubsystemPage());
    }

    private void SecuritySubsystem_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SecuritySubsystemPage());
    }
	}

}