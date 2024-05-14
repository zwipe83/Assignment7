/// <summary>
/// Filename: Location.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
using Assignment7.Structs;

namespace Assignment7.Classes
{
    public class Location
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private WorldPosition _worldPosition;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public WorldPosition WorldPosition
        {
            get => _worldPosition;
            set => _worldPosition = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Location() : this(new WorldPosition())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="worldPosition"></param>
        public Location(WorldPosition worldPosition)
        {
            WorldPosition = worldPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public Location(Location objToCopyFrom)
        {
            WorldPosition = objToCopyFrom.WorldPosition;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{WorldPosition.X:N2} {WorldPosition.Y:N2}";
        }
        #endregion
    }
}