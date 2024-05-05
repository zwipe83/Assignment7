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
        public Animal() : this(AnimalType.Mammal)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        public Animal(AnimalType animalType) : this(animalType, String.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        public Animal(AnimalType animalType, string name) : this(animalType, name, new File())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        /// <param name="animalId"></param>
        public Animal(AnimalType animalType, string name, File image) : this(animalType, name, image, new AnimalId())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalType"></param>
        /// <param name="name"></param>
        /// <param name="animalId"></param>
        /// <param name="image"></param>
        public Animal(AnimalType animalType, string name, File image, AnimalId animalId)
        {
            AnimalType = animalType;
            Name = name;
            Id = animalId;
            Image = image;
        }
        #endregion
    }
}