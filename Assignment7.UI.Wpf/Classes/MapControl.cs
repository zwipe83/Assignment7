using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MapControl
    {
        private Mapsui.UI.Wpf.MapControl _mapControl = new();

        public Mapsui.UI.Wpf.MapControl MapControlObj
        {
            get => _mapControl;
            set => _mapControl = value;
        }
    }
}