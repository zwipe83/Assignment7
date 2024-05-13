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
        private WorldPosition _worldPosition;

        public WorldPosition WorldPosition 
        { 
            get => _worldPosition;
            set => _worldPosition = value;
        }

        public Location() : this(new WorldPosition())
        {
        }

        public Location(WorldPosition worldPosition)
        {
            WorldPosition = worldPosition;
        }

        public Location(Location objToCopyFrom)
        {
            WorldPosition = objToCopyFrom.WorldPosition;
        }
        #region Public Methods

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