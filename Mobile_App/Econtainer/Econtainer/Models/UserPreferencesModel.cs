using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Econtainer.Models
{
    public class UserPreferencesModel : INotifyPropertyChanged
    {
        private string userId;
        private string languagePreference;
        private string themePreference;

        public string UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }

        public string LanguagePreference
        {
            get => languagePreference;
            set => SetProperty(ref languagePreference, value);
        }

        public string ThemePreference
        {
            get => themePreference;
            set => SetProperty(ref themePreference, value);
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
