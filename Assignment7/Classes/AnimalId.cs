
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
    /// 
    /// </summary>
    public class AnimalId
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private Guid _id;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AnimalId() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = Id.ToString();
            return s;
        }
        #endregion
    }
}