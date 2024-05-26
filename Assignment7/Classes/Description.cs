namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a description.
    /// </summary>
    public class Description
    {
        #region Fields

        /// <summary>
        /// The description string.
        /// </summary>
        private string _description;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Desc
        {
            get => _description;
            set => _description = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Description class with an empty description.
        /// </summary>
        public Description() : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Description class with the specified description.
        /// </summary>
        /// <param name="description">The description string.</param>
        public Description(string description)
        {
            Desc = description;
        }

        /// <summary>
        /// Initializes a new instance of the Description class by copying the description from another Description object.
        /// </summary>
        /// <param name="objToCopyFrom">The Description object to copy from.</param>
        public Description(Description objToCopyFrom)
        {
            Desc = objToCopyFrom.Desc;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// Returns a string that represents the current Description object.
        /// </summary>
        /// <returns>A string that represents the current Description object.</returns>
        public override string ToString() => Desc;
        #endregion
    }
}
