namespace Assignment7.UI.Wpf.Classes
{
    public class MapControl
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private Mapsui.UI.Wpf.MapControl _mapControl = new();
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Mapsui.UI.Wpf.MapControl MapControlObj
        {
            get => _mapControl;
            set => _mapControl = value;
        }
        #endregion
    }
}