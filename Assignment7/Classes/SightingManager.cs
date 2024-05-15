/// <summary>
/// Filename: SightingManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using System.Collections.ObjectModel;

namespace Assignment7.Classes
{
    public class SightingManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Sighting> _listOfSightings;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Sighting> ListOfSightings
        {
            get => _listOfSightings;
            private set => _listOfSightings = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SightingManager()
        {
            ListOfSightings = new ObservableCollection<Sighting>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sightingManager"></param>
        public SightingManager(SightingManager sightingManager)
        {
            ListOfSightings = new ObservableCollection<Sighting>(sightingManager.ListOfSightings);
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SightingManager DeepCopy()
        {
            SightingManager copy = new SightingManager();

            copy.ListOfSightings = new ObservableCollection<Sighting>(ListOfSightings);

            return copy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sighting"></param>
        public void AddSighting(Sighting sighting)
        {
            ListOfSightings.Add(sighting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sighting"></param>
        public void EditSighting(Sighting sighting)
        {
            int index = ListOfSightings.IndexOf(sighting);
            if (index != -1)
            {
                ListOfSightings[index] = sighting;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sighting"></param>
        public void DeleteSighting(Sighting sighting)
        {
            int index = ListOfSightings.IndexOf(sighting);
            if (index != -1)
            {
                ListOfSightings.Remove(sighting);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void FindSighting()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}