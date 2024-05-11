
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
                Animal animalCopy = new Animal();

                animalCopy.Name = animal.Name;
                animalCopy.AnimalId = animal.AnimalId;
                animalCopy.Image = animal.Image;
                animalCopy.Description = animal.Description;
                animalCopy.AnimalType = animal.AnimalType;

                copy.ListOfAnimals.Add(animalCopy);
            }

            return copy;
        }

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
        /// <exception cref="System.NotImplementedException"></exception>
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
        /// <exception cref="System.NotImplementedException"></exception>
        public Animal GetAnimal(AnimalId animalId)
        {
            return ListOfAnimals.FirstOrDefault(animal => animal.AnimalId == animalId);
        }
        #endregion
    }
}