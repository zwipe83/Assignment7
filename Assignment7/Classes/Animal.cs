/// <summary>
/// Filename: Animal.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment7.Enums;

namespace Assignment7.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class Animal
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private AnimalType _animalType;

        /// <summary>
        /// 
        /// </summary>
        private string _name;

        /// <summary>
        /// 
        /// </summary>
        private string? _description;

        /// <summary>
        /// 
        /// </summary>
        private AnimalId _id;

        /// <summary>
        /// 
        /// </summary>
        private File? _image;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public AnimalType AnimalType
        {
            get => _animalType;
            set => _animalType = value;
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
        public string? Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public AnimalId Id
        {
            get => _id; 
            set => _id = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public File Image
        {
            get => _image ?? new File(); 
            set => _image = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Animal() : this(new AnimalId())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        public Animal(AnimalId animalId) : this(animalId, AnimalType.Unknown)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        public Animal(AnimalId animalId, AnimalType animalType) : this(animalId, animalType, string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Animal(AnimalId animalId, AnimalType animalType, string name) : this(animalId, animalType, name, string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="image"></param>
        public Animal(AnimalId animalId, AnimalType animalType, string name, string description) : this(animalId, animalType, name, description, new File())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="image"></param>
        /// <param name="animalId"></param>
        public Animal(AnimalId animalId, AnimalType animalType, string name, string description, File image)
        {
            Id = animalId;
            AnimalType = animalType;
            Name = name;
            Description = description;
            Image = image;
        }
        #endregion
    }
}