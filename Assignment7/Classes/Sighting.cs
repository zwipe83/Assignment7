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
        private Date _date;

        /// <summary>
        /// 
        /// </summary>
        private Time _time;

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
        public Date Date
        {
            get => _date;
            set => _date = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public Time Time
        {
            get => _time;
            set => _time = value;

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
        public Sighting(SightingId sightingId, Animal animal, Location location) : this(sightingId, animal, location, new Date())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, Date date) : this(sightingId, animal, location, date, new Time())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, Date date, Time time) : this(sightingId, animal, location, date, time, new File())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, Date date, Time time, File image) : this(sightingId, animal, location, date, time, image, 1)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public Sighting(SightingId sightingId, Animal animal, Location location, Date date, Time time, File image, int count) 
        {
            Id = sightingId;
            Animal = animal;
            Location = location;
            Date = date;
            Time = time;
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
            Date = new Date(objToCopyFrom.Date); // Create a new instance of Date
            Time = new Time(objToCopyFrom.Time); // Create a new instance of Time
            Image = new File(objToCopyFrom.Image); // Create a new instance of File
            Count = objToCopyFrom.Count;
        }
        #endregion
    }
}