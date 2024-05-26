using Assignment7.Structs;

namespace Assignment7.UI.Wpf.Classes
{
    /// <summary>
    /// Represents a manager for the map functionality.
    /// </summary>
    public class MapManager
    {
        #region Fields

        /// <summary>
        /// The map instance managed by the MapManager.
        /// </summary>
        private Map _map;

        /// <summary>
        /// The map control used to display the map.
        /// </summary>
        private MapControl _mapControl = new();
        #endregion
        #region Properties

        /// <summary>
        /// Gets the map instance managed by the MapManager.
        /// </summary>
        public Map Map
        {
            get => _map;
        }

        /// <summary>
        /// Gets or sets the map control used to display the map.
        /// </summary>
        public MapControl MapControl
        {
            get => _mapControl;
            protected set => _mapControl = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MapManager class with the default world position.
        /// </summary>
        public MapManager() : this(new WorldPosition(1460179, 7522646))
        {
        }

        /// <summary>
        /// Initializes a new instance of the MapManager class with the specified world position.
        /// </summary>
        /// <param name="worldPosition">The world position to initialize the map with.</param>
        public MapManager(WorldPosition worldPosition)
        {
            _map = new Map(worldPosition);
        }
        #endregion
    }
}