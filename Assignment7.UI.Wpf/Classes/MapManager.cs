using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MapManager
    {
        private Map _map = new();
        private MapControl _mapControl = new();

        public Map Map { get { return _map; } }
        public MapControl MapControl { get { return _mapControl; } set { _mapControl = value; } }
    }
}