/// <summary>
/// Filename: SightingId.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class SightingId
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
            set
            {
                _id = value;
            }
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SightingId() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public SightingId(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public SightingId(SightingId objToCopyFrom)
        {
            Id= objToCopyFrom.Id;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}