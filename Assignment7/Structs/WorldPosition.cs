using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Structs
{
    public struct WorldPosition
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private double _x;

        /// <summary>
        /// 
        /// </summary>
        private double _y;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public double X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion
        #region Constructors

        public WorldPosition() : this(0.0, 0.0)
        {
        }
        public WorldPosition(double x, double y)
        {
            X = x; 
            Y = y;
        }
        #endregion
    }
}
