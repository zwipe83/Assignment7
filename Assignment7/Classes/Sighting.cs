/// <summary>
/// Filename: Sighting.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class Sighting
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// 
        /// </summary>
        private Location _location;

        /// <summary>
        /// 
        /// </summary>
        private CustomDateTime _when;

        /// <summary>
        /// 
        /// </summary>
        private SightingId _id;

        /// <summary>
        /// 
        /// </summary>
        private int _count;

        /// <summary>
        /// 
        /// </summary>
        private File _image;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public SightingId Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public Animal Animal
        {
            get => _animal;
            set => _animal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public Location Location
        {
            get => _location;
            set => _location = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public CustomDateTime When
        {
            get => _when;
            set => _when = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get => _count;
            set => _count = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public File Image
        {
            get => _image;
            set => _image = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sighting() : this(new SightingId())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId) : this(sightingId, new Animal())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal) : this(sightingId, animal, new Location())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location) : this(sightingId, animal, location, new CustomDateTime())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime) : this(sightingId, animal, location, dateTime, new File())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime, File image) : this(sightingId, animal, location, dateTime, image, 1)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime, File image, int count)
        {
            Id = sightingId;
            Animal = animal;
            Location = location;
            When = dateTime;
            Image = image;
            Count = count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objToCopyFrom"></param>
        public Sighting(Sighting objToCopyFrom)
        {
            Id = new SightingId(objToCopyFrom.Id); // Create a new instance of SightingId
            Animal = new Animal(objToCopyFrom.Animal); // Create a new instance of Animal
            Location = new Location(objToCopyFrom.Location); // Create a new instance of Location
            When = new CustomDateTime(objToCopyFrom.When); // Create a new instance of Date
            Image = new File(objToCopyFrom.Image); // Create a new instance of File
            Count = objToCopyFrom.Count;
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{When} {Animal.Name} {Count} {Location}";
        }
        #endregion
    }
}