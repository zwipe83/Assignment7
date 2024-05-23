
using System.Collections.ObjectModel;
using System.Linq.Expressions;

/// <summary>
/// Filename: AnimalManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimalManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Animal> _listOfAnimals;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Animal> ListOfAnimals
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
            ListOfAnimals = new ObservableCollection<Animal>();
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
        /// <returns></returns>
        public AnimalManager DeepCopy()
        {
            AnimalManager copy = new AnimalManager();

            copy.ListOfAnimals = new ObservableCollection<Animal>();
            foreach (Animal animal in this.ListOfAnimals)
            {
                Animal animalCopy = new Animal(animal.AnimalId, animal.AnimalType, animal.Name, animal.Description, animal.Image);

                copy.ListOfAnimals.Add(animalCopy);
            }

            return copy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            try
            {
                if (animal is not null)
                {
                    ListOfAnimals.Add(animal);
                }
                else
                {
                    throw new ArgumentNullException("Can't add null object to list of animals");
                }
            }
            catch
            { 
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        public void ChangeAnimal(Animal animal)
        {
            int index = ListOfAnimals.IndexOf(animal);
            if (index != -1)
            {
                ListOfAnimals[index] = animal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        public void DeleteAnimal(Animal animal)
        {
            int index = ListOfAnimals.IndexOf(animal);
            if (index != -1)
            {
                ListOfAnimals.Remove(animal);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AnimalId> GetAnimalIds()
        {
            List<AnimalId> animalIds = new List<AnimalId>();

            foreach (Animal animal in ListOfAnimals)
            {
                animalIds.Add(animal.AnimalId);
            }

            return animalIds;
        }
        #endregion
    }
}