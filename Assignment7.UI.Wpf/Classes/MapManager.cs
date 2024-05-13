using Assignment7.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7.UI.Wpf.Classes
{
    public class MapManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private Map _map;

        /// <summary>
        /// 
        /// </summary>
        private MapControl _mapControl = new();
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Map Map 
        { 
            get => _map;
        }

        /// <summary>
        /// 
        /// </summary>
        public MapControl MapControl 
        { 
            get => _mapControl; 
            protected set => _mapControl = value; 
        } 
        #endregion

        public MapManager() : this(new WorldPosition(1460179, 7522646))
        { 
        }

        public MapManager(WorldPosition worldPosition)
        {
            _map = new Map(worldPosition);
        }
    }
}