using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.Models
{
    public class SecurityModel : INotifyPropertyChanged
    {
        private int containerId;
        private bool isDoorLocked;
        private bool hasMotionDetected;

        public int ContainerId
        {
            get => containerId;
            set => SetProperty(ref containerId, value);
        }

        public bool IsDoorLocked
        {
            get => isDoorLocked;
            set => SetProperty(ref isDoorLocked, value);
        }

        public bool HasMotionDetected
        {
            get => hasMotionDetected;
            set => SetProperty(ref hasMotionDetected, value);
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
