using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment7.UI.Wpf.ViewModels
{
    public class AnimalWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string imagePath = string.Empty;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
