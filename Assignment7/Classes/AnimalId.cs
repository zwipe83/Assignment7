
using System.Runtime.Serialization;

/// <summary>
/// Filename: AnimalId.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents an identifier for an animal.
    /// </summary>
    public class AnimalId
    {
        #region Fields

        /// <summary>
        /// The unique identifier for the animal.
        /// </summary>
        private Guid _id;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the animal.
        /// </summary>
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the AnimalId class with a new unique identifier.
        /// </summary>
        public AnimalId() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the AnimalId class with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the animal.</param>
        public AnimalId(Guid id)
        {
            Id = id;
        }
        #endregion

        // Deserialization constructor
        public AnimalId(SerializationInfo info, StreamingContext context)
        {
            // Retrieve the serialized value of the "_id" field from the SerializationInfo object
            _id = (Guid)info.GetValue("_id", typeof(Guid));
        }

        #region Overridden Methods

        /// <summary>
        /// Returns a string representation of the AnimalId object.
        /// </summary>
        /// <returns>A string representation of the AnimalId object.</returns>
        public override string ToString()
        {
            string s = Id.ToString();
            return s;
        }
        #endregion
    }
}