
using System.Collections.ObjectModel;

/// <summary>
/// Filename: AnimalManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a manager for managing a collection of animals.
    /// </summary>
    public class AnimalManager
    {
        #region Fields

        /// <summary>
        /// The list of animals.
        /// </summary>
        private ObservableCollection<Animal> _listOfAnimals;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the list of animals.
        /// </summary>
        public ObservableCollection<Animal> ListOfAnimals
        {
            get => _listOfAnimals;
            protected set => _listOfAnimals = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the AnimalManager class.
        /// </summary>
        public AnimalManager()
        {
            ListOfAnimals = new ObservableCollection<Animal>();
        }

        /// <summary>
        /// Initializes a new instance of the AnimalManager class by copying from another AnimalManager object.
        /// </summary>
        /// <param name="objToCopyFrom">The AnimalManager object to copy from.</param>
        public AnimalManager(AnimalManager objToCopyFrom)
        {
            ListOfAnimals = objToCopyFrom.ListOfAnimals;
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Creates a deep copy of the AnimalManager object.
        /// </summary>
        /// <returns>A new instance of the AnimalManager class that is a deep copy of this instance.</returns>
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
        /// Adds an animal to the list of animals.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
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
        /// Changes an existing animal in the list of animals.
        /// </summary>
        /// <param name="animal">The animal to change.</param>
        public void ChangeAnimal(Animal animal)
        {
            int index = ListOfAnimals.IndexOf(animal);
            if (index != -1)
            {
                ListOfAnimals[index] = animal;
            }
        }

        /// <summary>
        /// Deletes an animal from the list of animals.
        /// </summary>
        /// <param name="animal">The animal to delete.</param>
        public void DeleteAnimal(Animal animal)
        {
            int index = ListOfAnimals.IndexOf(animal);
            if (index != -1)
            {
                ListOfAnimals.Remove(animal);
            }
        }

        /// <summary>
        /// Gets a list of animal IDs from the list of animals.
        /// </summary>
        /// <returns>A list of animal IDs.</returns>
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