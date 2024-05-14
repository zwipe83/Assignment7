using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment7.UI.Wpf.ViewModels
{
    //TODO: Remove?
    public class AnimalWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string imagePath = "Images/MyPicture.jpg";
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
