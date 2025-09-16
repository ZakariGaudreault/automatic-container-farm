using Econtainer.DataRepos;
using Econtainer.Models;
using System.Collections.ObjectModel;

public class ContainerViewModel : ViewModelBase
{
    private readonly ContainerRepository containerRepository;
    private ObservableCollection<ContainerModel> containers;

    public ContainerViewModel()
    {
        containerRepository = new ContainerRepository();
        Containers = new ObservableCollection<ContainerModel>(containerRepository.GetAllContainers());
        containerRepository.DataChanged += (s, e) => LoadContainers();
    }

    public ObservableCollection<ContainerModel> Containers
    {
        get => containers;
        set => SetProperty(ref containers, value);
    }

    private void LoadContainers()
    {
        Containers.Clear();
        foreach (var container in containerRepository.GetAllContainers())
        {
            Containers.Add(container);
        }
    }
}