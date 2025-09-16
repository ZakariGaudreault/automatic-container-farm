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
    public class TrackingViewModel : ViewModelBase
    {
        private readonly TrackingRepository trackingRepository;
        private ObservableCollection<TrackingModel> trackings;

        public TrackingViewModel()
        {
            trackingRepository = new TrackingRepository();
            Trackings = new ObservableCollection<TrackingModel>(trackingRepository.GetAllTrackings());
            trackingRepository.DataChanged += (s, e) => LoadTrackings();
        }

        public ObservableCollection<TrackingModel> Trackings
        {
            get => trackings;
            set => SetProperty(ref trackings, value);
        }

        private void LoadTrackings()
        {
            Trackings.Clear();
            foreach (var tracking in trackingRepository.GetAllTrackings())
            {
                Trackings.Add(tracking);
            }
        }
    }
}
