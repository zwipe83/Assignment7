namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a custom implementation of DateTime.
    /// </summary>
    public class CustomDateTime
    {
        #region Fields

        /// <summary>
        /// The underlying DateTime value.
        /// </summary>
        private DateTime _dateTime;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the DateTime value.
        /// </summary>
        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the CustomDateTime class with the current date and time.
        /// </summary>
        public CustomDateTime() : this(new DateTime())
        {
        }

        /// <summary>
        /// Initializes a new instance of the CustomDateTime class with the specified DateTime value.
        /// </summary>
        /// <param name="dateTime">The DateTime value.</param>
        public CustomDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        /// <summary>
        /// Initializes a new instance of the CustomDateTime class by copying the DateTime value from another CustomDateTime object.
        /// </summary>
        /// <param name="objToCopyFrom">The CustomDateTime object to copy from.</param>
        public CustomDateTime(CustomDateTime objToCopyFrom)
        {
            DateTime = objToCopyFrom.DateTime;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// Returns a string that represents the CustomDateTime object.
        /// </summary>
        /// <returns>A string representation of the CustomDateTime object.</returns>
        public override string ToString()
        {
            return $"{DateTime.Date:yyyy-MM-dd} {DateTime.TimeOfDay:hh\\:mm}";
        }
        #endregion
    }
}
