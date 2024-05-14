namespace Assignment7.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomDateTime
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private DateTime _dateTime;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public CustomDateTime() : this(new DateTime())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        public CustomDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public CustomDateTime(CustomDateTime objToCopyFrom)
        {
            DateTime = objToCopyFrom.DateTime;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{DateTime.Date:yyyy-MM-dd} {DateTime.TimeOfDay:hh\\:mm}";
        }
        #endregion
    }
}
