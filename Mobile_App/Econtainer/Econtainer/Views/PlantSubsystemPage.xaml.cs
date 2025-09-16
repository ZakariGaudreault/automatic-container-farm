using Econtainer.Models;
using Econtainer.ViewModels;
using Microsoft.Maui.Controls;
using System.Linq;

namespace Econtainer.Views;

public partial class PlantSubsystemPage : ContentPage
{
    public PlantSubsystemPage()
    {
        InitializeComponent();
        BindingContext = new ContainerViewModel();
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedContainer = e.CurrentSelection.FirstOrDefault() as ContainerModel;
        if (selectedContainer != null)
        {
            await Navigation.PushAsync(new PlantSubsystemInfo(selectedContainer.Id));
        }
    }

}
