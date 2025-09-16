using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Econtainer.Models
{
    public class ContainerModel : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private double longitude;
        private double latitude;
        private double temperature;
        private double humidity;
        private double waterLevel;
        private List<(DateTime Time, double Temperature)> tempHistory = new List<(DateTime, double)>();
        private EnvironmentControlModel environmentControl = new EnvironmentControlModel();

        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        public List<(DateTime Time, double Temperature)> TempHistory
        {
            get => tempHistory;
            set => SetProperty(ref tempHistory, value);
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public double Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }

        public double WaterLevel
        {
            get => waterLevel;
            set => SetProperty(ref waterLevel, value);
        }

        public EnvironmentControlModel EnvironmentControl
        {
            get => environmentControl;
            set => SetProperty(ref environmentControl, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
