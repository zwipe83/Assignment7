namespace Assignment7.UI.Wpf.Classes
{
    /// <summary>
    /// Represents a custom map control.
    /// </summary>
    public class MapControl
    {
        #region Fields

        /// <summary>
        /// The underlying Mapsui map control.
        /// </summary>
        private Mapsui.UI.Wpf.MapControl _mapControl = new();
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the Mapsui map control object.
        /// </summary>
        public Mapsui.UI.Wpf.MapControl MapControlObj
        {
            get => _mapControl;
            set => _mapControl = value;
        }
        #endregion
    }
}