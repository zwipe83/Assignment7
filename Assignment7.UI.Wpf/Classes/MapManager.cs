using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MapManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private Map _map = new();

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
    }
}