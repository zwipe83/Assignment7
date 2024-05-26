/// <summary>
/// Filename: File.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a file.
    /// </summary>
    public class File
    {
        #region Fields

        /// <summary>
        /// The relative path of the file.
        /// </summary>
        private string _path; //FIXED: Maybe path isnt needed. Consider if you move the app to a different location. Path will need to be updated. Changed to relative path

        /// <summary>
        /// The name of the file.
        /// </summary>
        private string _name;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the relative path of the file.
        /// </summary>
        public string Path
        {
            get => _path;
            set => _path = value;
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class with empty path and name.
        /// </summary>
        public File() : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class with the specified path and name.
        /// </summary>
        /// <param name="path">The relative path of the file.</param>
        /// <param name="name">The name of the file.</param>
        public File(string path, string name)
        {
            Path = path;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class by copying the properties from another <see cref="File"/> object.
        /// </summary>
        /// <param name="objToCopyFrom">The <see cref="File"/> object to copy from.</param>
        public File(File objToCopyFrom)
        {
            Path = objToCopyFrom.Path;
            Name = objToCopyFrom.Name;
        }
        #endregion
    }
}