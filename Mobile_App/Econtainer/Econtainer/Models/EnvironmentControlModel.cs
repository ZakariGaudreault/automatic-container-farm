using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.Models
{
    public class EnvironmentControlModel : INotifyPropertyChanged
    {
        private int lightIntensity;
        private bool isFanOn;
        private double temperatureSetPoint;
        private double humiditySetPoint;
        private int containerId;

        public int ContainerId
        {
            get => containerId;
            set => SetProperty(ref containerId, value);
        }
        public int LightIntensity
        {
            get => lightIntensity;
            set => SetProperty(ref lightIntensity, value);
        }

        public bool IsFanOn
        {
            get => isFanOn;
            set => SetProperty(ref isFanOn, value);
        }

        public double TemperatureSetPoint
        {
            get => temperatureSetPoint;
            set => SetProperty(ref temperatureSetPoint, value);
        }

        public double HumiditySetPoint
        {
            get => humiditySetPoint;
            set => SetProperty(ref humiditySetPoint, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
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
