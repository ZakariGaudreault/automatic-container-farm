using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.Models
{
    public class NotificationModel : INotifyPropertyChanged
    {
        private string message;
        private DateTime timestamp;

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public DateTime Timestamp
        {
            get => timestamp;
            set => SetProperty(ref timestamp, value);
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
