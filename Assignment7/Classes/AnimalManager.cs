/// <summary>
/// Filename: AnimalManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class AnimalManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private List<Animal> _listOfAnimals;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public List<Animal> ListOfAnimals
        {
            get => _listOfAnimals;
            protected set => _listOfAnimals = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager() 
        { 
            ListOfAnimals = new List<Animal>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public AnimalManager(AnimalManager objToCopyFrom)
        {
            ListOfAnimals = objToCopyFrom.ListOfAnimals;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddAnimal(Animal animal)
        {
            ListOfAnimals.Add(animal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ChangeAnimal()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void DeleteAnimal()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void GetAnimal()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}