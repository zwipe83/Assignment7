/// <summary>
/// Filename: File.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class File
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private string _path; //TODO: Maybe path isnt needed. Consider if you move the app to a different location. Path will need to be updated

        /// <summary>
        /// 
        /// </summary>
        private string _name;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get => _path;
            set => _path = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        { 
            get => System.IO.Path.Combine(Path, Name);
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public File() : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public File(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public File(File objToCopyFrom)
        {
            Path = objToCopyFrom.Path;
            Name = objToCopyFrom.Name;
        }
        #endregion
    }
}