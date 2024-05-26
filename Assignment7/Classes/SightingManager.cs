/// <summary>
/// Filename: SightingManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using System.Collections.ObjectModel;

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a manager for handling sightings.
    /// </summary>
    public class SightingManager
    {
        #region Fields

        /// <summary>
        /// The list of sightings.
        /// </summary>
        private ObservableCollection<Sighting> _listOfSightings;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the list of sightings.
        /// </summary>
        public ObservableCollection<Sighting> ListOfSightings
        {
            get => _listOfSightings;
            private set => _listOfSightings = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SightingManager"/> class.
        /// </summary>
        public SightingManager()
        {
            ListOfSightings = new ObservableCollection<Sighting>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SightingManager"/> class with a deep copy of another <see cref="SightingManager"/> object.
        /// </summary>
        /// <param name="sightingManager">The <see cref="SightingManager"/> object to copy.</param>
        public SightingManager(SightingManager sightingManager)
        {
            ListOfSightings = new ObservableCollection<Sighting>(sightingManager.ListOfSightings);
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Creates a deep copy of the <see cref="SightingManager"/> object.
        /// </summary>
        /// <returns>A new instance of the <see cref="SightingManager"/> class that is a deep copy of this instance.</returns>
        public SightingManager DeepCopy()
        {
            SightingManager copy = new SightingManager();

            copy.ListOfSightings = new ObservableCollection<Sighting>(ListOfSightings);

            return copy;
        }

        /// <summary>
        /// Adds a sighting to the list of sightings.
        /// </summary>
        /// <param name="sighting">The sighting to add.</param>
        public void AddSighting(Sighting sighting)
        {
            ListOfSightings.Add(sighting);
        }

        /// <summary>
        /// Edits a sighting in the list of sightings.
        /// </summary>
        /// <param name="sighting">The sighting to edit.</param>
        public void EditSighting(Sighting sighting)
        {
            int index = ListOfSightings.IndexOf(sighting);
            if (index != -1)
            {
                ListOfSightings[index] = sighting;
            }
        }

        /// <summary>
        /// Deletes a sighting from the list of sightings.
        /// </summary>
        /// <param name="sighting">The sighting to delete.</param>
        public void DeleteSighting(Sighting sighting)
        {
            int index = ListOfSightings.IndexOf(sighting);
            if (index != -1)
            {
                ListOfSightings.Remove(sighting);
            }
        }

        /// <summary>
        /// Finds a sighting.
        /// </summary>
        /// <exception cref="System.NotImplementedException">Thrown when the method is not implemented.</exception>
        public void FindSighting()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}