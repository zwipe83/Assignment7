using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Structs
{
    internal struct WorldPosition
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private decimal _x;

        /// <summary>
        /// 
        /// </summary>
        private decimal _y;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        internal decimal X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// 
        /// </summary>
        internal decimal Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion
    }
}
