using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
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