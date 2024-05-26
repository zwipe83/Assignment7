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
    /// Animal class
    /// </summary>
    public class Animal
    {
        #region Fields

        /// <summary>
        /// The type of the animal
        /// </summary>
        private AnimalType _animalType;

        /// <summary>
        /// The name of the animal
        /// </summary>
        private string _name;

        /// <summary>
        /// The description of the animal
        /// </summary>
        private string? _description;

        /// <summary>
        /// The unique identifier of the animal
        /// </summary>
        private AnimalId _animalId;

        /// <summary>
        /// The image file of the animal
        /// </summary>
        private File? _image;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the type of the animal
        /// </summary>
        public AnimalType AnimalType
        {
            get => _animalType;
            set => _animalType = value;
        }

        /// <summary>
        /// Gets or sets the name of the animal
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets or sets the description of the animal
        /// </summary>
        public string? Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the animal
        /// </summary>
        public AnimalId AnimalId
        {
            get => _animalId;
            set => _animalId = value;
        }

        /// <summary>
        /// Gets or sets the image file of the animal
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
        /// Constructor with the specified animal identifier
        /// </summary>
        /// <param name="animalId">The animal identifier</param>
        public Animal(AnimalId animalId) : this(animalId, AnimalType.Unknown)
        {
        }

        /// <summary>
        /// Constructor with the specified animal identifier and type
        /// </summary>
        /// <param name="animalId">The animal identifier</param>
        /// <param name="animalType">The animal type</param>
        public Animal(AnimalId animalId, AnimalType animalType) : this(animalId, animalType, string.Empty)
        {
        }

        /// <summary>
        /// Constructor with the specified animal identifier, type, and name
        /// </summary>
        /// <param name="animalId">The animal identifier</param>
        /// <param name="animalType">The animal type</param>
        /// <param name="name">The name of the animal</param>
        public Animal(AnimalId animalId, AnimalType animalType, string name) : this(animalId, animalType, name, string.Empty)
        {
        }

        /// <summary>
        /// Constructor with the specified animal identifier, type, name, and description
        /// </summary>
        /// <param name="animalId">The animal identifier</param>
        /// <param name="animalType">The animal type</param>
        /// <param name="name">The name of the animal</param>
        /// <param name="description">The description of the animal</param>
        public Animal(AnimalId animalId, AnimalType animalType, string name, string description) : this(animalId, animalType, name, description, new File())
        {
        }

        /// <summary>
        /// Constructor with the specified animal identifier, type, name, description, and image
        /// </summary>
        /// <param name="animalId">The animal identifier</param>
        /// <param name="animalType">The animal type</param>
        /// <param name="name">The name of the animal</param>
        /// <param name="description">The description of the animal</param>
        /// <param name="image">The image file of the animal</param>
        public Animal(AnimalId animalId, AnimalType animalType, string name, string description, File image)
        {
            AnimalId = animalId;
            AnimalType = animalType;
            Name = name;
            Description = description;
            Image = image;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="objToCopyFrom">The animal object to copy from</param>
        public Animal(Animal objToCopyFrom)
        {
            AnimalId = objToCopyFrom.AnimalId;
            AnimalType = objToCopyFrom.AnimalType;
            Name = objToCopyFrom.Name;
            Description = objToCopyFrom.Description;
            Image = objToCopyFrom.Image;
        }
        #endregion
    }
}