/// <summary>
/// Filename: Sighting.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a sighting of an animal at a specific location and time.
    /// </summary>
    public class Sighting
    {
        #region Fields

        /// <summary>
        /// The animal observed in the sighting.
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// The location where the sighting occurred.
        /// </summary>
        private Location _location;

        /// <summary>
        /// The date and time of the sighting.
        /// </summary>
        private CustomDateTime _when;

        /// <summary>
        /// The unique identifier for the sighting.
        /// </summary>
        private SightingId _id;

        /// <summary>
        /// The count of animals observed in the sighting.
        /// </summary>
        private int _count;

        /// <summary>
        /// The image associated with the sighting.
        /// </summary>
        private File _image;

        /// <summary>
        /// The description of the sighting.
        /// </summary>
        private Description _description;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the sighting.
        /// </summary>
        public SightingId Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Gets or sets the animal observed in the sighting.
        /// </summary>
        public Animal Animal
        {
            get => _animal;
            set => _animal = value;
        }

        /// <summary>
        /// Gets or sets the location where the sighting occurred.
        /// </summary>
        public Location Location
        {
            get => _location;
            set => _location = value;
        }

        /// <summary>
        /// Gets or sets the date and time of the sighting.
        /// </summary>
        public CustomDateTime When
        {
            get => _when;
            set => _when = value;
        }

        /// <summary>
        /// Gets or sets the count of animals observed in the sighting.
        /// </summary>
        public int Count
        {
            get => _count;
            set => _count = value;
        }

        /// <summary>
        /// Gets or sets the image associated with the sighting.
        /// </summary>
        public File Image
        {
            get => _image;
            set => _image = value;
        }

        /// <summary>
        /// Gets or sets the description of the sighting.
        /// </summary>
        public Description Description
        {
            get => _description;
            set => _description = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class.
        /// </summary>
        public Sighting() : this(new SightingId())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        public Sighting(SightingId sightingId) : this(sightingId, new Animal())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID and animal.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        public Sighting(SightingId sightingId, Animal animal) : this(sightingId, animal, new Location())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID, animal, and location.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        /// <param name="location">The location where the sighting occurred.</param>
        public Sighting(SightingId sightingId, Animal animal, Location location) : this(sightingId, animal, location, new CustomDateTime())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID, animal, location, and date and time.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        /// <param name="location">The location where the sighting occurred.</param>
        /// <param name="dateTime">The date and time of the sighting.</param>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime) : this(sightingId, animal, location, dateTime, new File())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID, animal, location, date and time, and image.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        /// <param name="location">The location where the sighting occurred.</param>
        /// <param name="dateTime">The date and time of the sighting.</param>
        /// <param name="image">The image associated with the sighting.</param>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime, File image) : this(sightingId, animal, location, dateTime, image, new Description(string.Empty))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID, animal, location, date and time, image, and description.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        /// <param name="location">The location where the sighting occurred.</param>
        /// <param name="dateTime">The date and time of the sighting.</param>
        /// <param name="image">The image associated with the sighting.</param>
        /// <param name="description">The description of the sighting.</param>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime, File image, Description description) : this(sightingId, animal, location, dateTime, image, description, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class with the specified sighting ID, animal, location, date and time, image, description, and count.
        /// </summary>
        /// <param name="sightingId">The sighting ID.</param>
        /// <param name="animal">The animal observed in the sighting.</param>
        /// <param name="location">The location where the sighting occurred.</param>
        /// <param name="dateTime">The date and time of the sighting.</param>
        /// <param name="image">The image associated with the sighting.</param>
        /// <param name="description">The description of the sighting.</param>
        /// <param name="count">The count of animals observed in the sighting.</param>
        public Sighting(SightingId sightingId, Animal animal, Location location, CustomDateTime dateTime, File image, Description description, int count)
        {
            Id = sightingId;
            Animal = animal;
            Location = location;
            When = dateTime;
            Image = image;
            Count = count;
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sighting"/> class by copying the properties of another <see cref="Sighting"/> object.
        /// </summary>
        /// <param name="objToCopyFrom">The <see cref="Sighting"/> object to copy from.</param>
        public Sighting(Sighting objToCopyFrom)
        {
            Id = new SightingId(objToCopyFrom.Id); // Create a new instance of SightingId
            Animal = new Animal(objToCopyFrom.Animal); // Create a new instance of Animal
            Location = new Location(objToCopyFrom.Location); // Create a new instance of Location
            When = new CustomDateTime(objToCopyFrom.When); // Create a new instance of Date
            Image = new File(objToCopyFrom.Image); // Create a new instance of File
            Count = objToCopyFrom.Count;
            Description = new Description(objToCopyFrom.Description);
        }
        #endregion
        #region Overridden Methods

        /// <summary>
        /// Returns a string representation of the <see cref="Sighting"/> object.
        /// </summary>
        /// <returns>A string representation of the <see cref="Sighting"/> object.</returns>
        public override string ToString()
        {
            return $"{When} {Animal.Name} {Count} {Description}";
        }
        #endregion
    }
}