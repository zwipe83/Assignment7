/// <summary>
/// Filename: SightingId.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a unique identifier for a sighting.
    /// </summary>
    public class SightingId
    {
        #region Fields

        /// <summary>
        /// The unique identifier for the sighting.
        /// </summary>
        private Guid _id;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the sighting.
        /// </summary>
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SightingId class with a new unique identifier.
        /// </summary>
        public SightingId() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the SightingId class with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the sighting.</param>
        public SightingId(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the SightingId class by copying the unique identifier from another SightingId object.
        /// </summary>
        /// <param name="objToCopyFrom">The SightingId object to copy the unique identifier from.</param>
        public SightingId(SightingId objToCopyFrom)
        {
            Id = objToCopyFrom.Id;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// Returns a string representation of the unique identifier.
        /// </summary>
        /// <returns>A string representation of the unique identifier.</returns>
        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}