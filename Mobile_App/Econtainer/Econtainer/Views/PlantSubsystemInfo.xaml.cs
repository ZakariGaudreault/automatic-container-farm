using Econtainer.Models;
using Econtainer.DataRepos;
using Microsoft.Maui.Controls;

namespace Econtainer.Views;

public partial class PlantSubsystemInfo : ContentPage
{
    private readonly ContainerRepository _containerRepository;
    private readonly EnvironmentControlRepository _environmentControlRepo;

    public PlantSubsystemInfo(int selectedContainerId)
    {
        InitializeComponent();

        _containerRepository = new ContainerRepository();
        _environmentControlRepo = new EnvironmentControlRepository();

        ContainerModel selectedContainer = _containerRepository.GetContainerById(selectedContainerId);
        EnvironmentControlModel selectedControl = _environmentControlRepo.GetAllControls().FirstOrDefault(ec => ec.ContainerId == selectedContainerId);

        if (selectedContainer != null)
        {
            selectedContainer.EnvironmentControl = selectedControl; // Make sure this line properly links your data
            BindingContext = selectedContainer;
        }
        else
        {
            DisplayAlert("Error", "Container not found", "OK");
        }
    }

}
