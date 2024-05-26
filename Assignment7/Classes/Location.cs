/// <summary>
/// Filename: Location.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
using Assignment7.Structs;

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a location in the world.
    /// </summary>
    public class Location
    {
        #region Fields

        /// <summary>
        /// The world position of the location.
        /// </summary>
        private WorldPosition _worldPosition;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the world position of the location.
        /// </summary>
        public WorldPosition WorldPosition
        {
            get => _worldPosition;
            set => _worldPosition = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class with default values.
        /// </summary>
        public Location() : this(new WorldPosition())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class with the specified world position.
        /// </summary>
        /// <param name="worldPosition">The world position of the location.</param>
        public Location(WorldPosition worldPosition)
        {
            WorldPosition = worldPosition;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class by copying the values from another <see cref="Location"/> object.
        /// </summary>
        /// <param name="objToCopyFrom">The <see cref="Location"/> object to copy from.</param>
        public Location(Location objToCopyFrom)
        {
            WorldPosition = objToCopyFrom.WorldPosition;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// Returns a string that represents the current <see cref="Location"/> object.
        /// </summary>
        /// <returns>A string representation of the current <see cref="Location"/> object.</returns>
        public override string ToString()
        {
            return $"{WorldPosition.X:N2} {WorldPosition.Y:N2}";
        }
        #endregion
    }
}