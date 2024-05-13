using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Classes
{
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
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{DateTime.Date.ToString("yyyy-MM-dd")} {DateTime.TimeOfDay.ToString("hh\\:mm")}";
        }
        #endregion
    }
}
