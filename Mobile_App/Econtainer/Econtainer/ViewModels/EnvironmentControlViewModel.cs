using Econtainer.DataRepos;
using Econtainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.ViewModels
{
    public class EnvironmentControlViewModel : ViewModelBase
    {
        private readonly EnvironmentControlRepository environmentControlRepository;
        private ObservableCollection<EnvironmentControlModel> environmentControls;

        public EnvironmentControlViewModel()
        {
            environmentControlRepository = new EnvironmentControlRepository();
            EnvironmentControls = new ObservableCollection<EnvironmentControlModel>(environmentControlRepository.GetAllControls());
            environmentControlRepository.DataChanged += (s, e) => LoadEnvironmentControls();
        }

        public ObservableCollection<EnvironmentControlModel> EnvironmentControls
        {
            get => environmentControls;
            set => SetProperty(ref environmentControls, value);
        }

        private void LoadEnvironmentControls()
        {
            EnvironmentControls.Clear();
            foreach (var control in environmentControlRepository.GetAllControls())
            {
                EnvironmentControls.Add(control);
            }
        }
    }
}
