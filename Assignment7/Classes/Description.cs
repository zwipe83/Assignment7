using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment7.Classes
{
    public class Description
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private string _description;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Desc
        {
            get => _description; 
            set => _description = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Description() : this(string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public Description(string description)
        {
            Desc = description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public Description(Description objToCopyFrom)
        {
            Desc = objToCopyFrom.Desc;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Desc;
        #endregion
    }
}
