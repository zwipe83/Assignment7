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
        private ObservableCollection<Sighting> _listOfSightings;

        public ObservableCollection<Sighting> ListOfSightings
        {
            get => _listOfSightings;
            private set => _listOfSightings = value;
        }

        public SightingManager() 
        { 
            ListOfSightings = new ObservableCollection<Sighting>();
        }

        public SightingManager(SightingManager sightingManager)
        {
            ListOfSightings = new ObservableCollection<Sighting>(sightingManager.ListOfSightings);
        }

        public void AddSighting(Sighting sighting)
        {
            ListOfSightings.Add(sighting);
        }

        public void ChangeSighting()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSighting()
        {
            throw new System.NotImplementedException();
        }

        public void FindSighting()
        {
            throw new System.NotImplementedException();
        }
    }
}