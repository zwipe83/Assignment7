using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment7.UI.Wpf.ViewModels
{
    /// <summary>
    /// Represents the view model for the AnimalWindow.
    /// </summary>
    public class AnimalWindowViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Fields

        /// <summary>
        /// The path of the image.
        /// </summary>
        private string imagePath = string.Empty;

        /// <summary>
        /// Gets or sets the path of the image.
        /// </summary>
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
        #endregion
    }
}
